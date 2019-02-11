/*
 * StrikeSoft Properties Manager
 * Version: Build 2
 * 
 * Build 1: Tuesday, December 23rd, 2008
 *      * (17:57) A base namespace to help with collections of properties of the
 *                purpose of storing them into a single-line database, based off of my
 *                old IFD code, which was originally inspired from internet cookies.
 * Build 2: Sunday, January 5th, 2014
 *      * (09:27) Ported to C#.
 */

using System.Collections.Generic;

namespace IOLib
{
    public class PropertiesCollection : List<PropertyItem>
    {
        private const char Seperator = ';';

        public PropertiesCollection() { }

        public PropertiesCollection(PropertiesCollection clone)
        {
            if(clone == null || clone.Count == 0) return;
            for(int index = 0; index < clone.Count; index++) {
                this.Add(new PropertyItem(clone[index]));
            } // index
        } //Clone

        public PropertiesCollection(params PropertyItem[] items)
        {
            if(items == null || items.Length == 0) return;
            for(int index = 0; index < items.Length; index++) {
                this.Add(new PropertyItem(items[index]));
            } // index
        } //Clone

        public PropertiesCollection(string tag) { this.FromString(tag); }

        public PropertyItem Add(string name, string value)
        {
            base.Add(new PropertyItem(name, value));
            return base[base.Count - 1];
        } // Add

        public PropertyItem Add(string unparsed)
        {
            base.Add(new PropertyItem(unparsed));
            return base[base.Count - 1];
        } // Add

        /// <returns>Returns -1 if not found, else wise an integer starting from 0.</returns>
        public int FindIndex(string name)
        {
            if(base.Count > 0) {
                for(int index = 0; index < base.Count; index++) {
                    if(string.Equals(base[index].Name, name, System.StringComparison.CurrentCultureIgnoreCase)) return index;
                } // index
            }

            return -1;
        } // FindIndex

        public override string ToString()
        {
            string result = "";

            if(base.Count > 0) {
                for(int index = 0; index < base.Count; index++) {
                    result = ((result == "") ? "" : result + Seperator) + this.PrepareString(base[index].ToString());
                } // index
            }

            return result;
        } // ToString

        public bool FromString(string value)
        {
            if(string.IsNullOrEmpty(value)) return true;
            string[] values = value.Split(Seperator);
            if(values == null) return true;

            foreach(string valueUnparsed in values) {
                base.Add(new PropertyItem(this.FixString(valueUnparsed)));
            } // valueUnparsed

            return true;
        } // FromString

        private string PrepareString(string value) { return value.Replace(Seperator.ToString(), "%SEPERATOR%"); }

        private string FixString(string value) { return value.Replace("%SEPERATOR%", Seperator.ToString()); }

        public string GetValue(string key, string def = "")
        {
            int index = this.FindIndex(key);
            if(index < 0) return def;
            return base[index].Value;
        } // GetValue

        public void SetValue(string key, string value)
        {
            int index = this.FindIndex(key);
            if(index < 0)
                this.Add(key, value);
            else
                base[index].Value = value;
        } // SetValue

        public void AppendFromData(XINI.EntryItem parentEntry, XINI.AppendModes appendMode)
        {
            if(parentEntry == null) return;

            if(appendMode == XINI.AppendModes.Read) {
                if(parentEntry.Children.Count > 0) {
                    foreach(XINI.EntryItem childEntry in parentEntry.Children) {
                        PropertyItem newItem = new PropertyItem();
                        newItem.AppendFromData(childEntry, appendMode);
                        base.Add(newItem);
                    } //childEntry
                }
            } else if(appendMode == XINI.AppendModes.Save) {
                if(base.Count > 0) {
                    for(int index = 0; index < base.Count; index++) {
                        XINI.EntryItem childEntry = parentEntry.AppendChildEntry("Property", appendMode);
                        base[index].AppendFromData(childEntry, appendMode);
                    } // index
                }
            }
        } // AppendFromData
    } // PropertiesCollection

    public class PropertyItem : XINI.BaseContainer
    {

        public string Name = "";
        public string Value = "";

        private const string Seperator = "=";

        public PropertyItem() {}

        public PropertyItem(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        } // New

        public PropertyItem(string unparsed) { this.FromString(unparsed); }

        public PropertyItem(PropertyItem clone)
        {
            if(clone == null) return;
            this.Name = clone.Name;
            this.Value = clone.Value;
        } //Clone

        public override string ToString() { return this.PrepareString(this.Name) + Seperator + this.PrepareString(this.Value); }

        public bool FromString(string value)
        {
            int pos = value.IndexOf(Seperator);
            if(pos < 0) return false;

            string leftOf  = value.Substring(0, pos);
            string rightOf = value.Substring(1 + pos);

            this.Name = this.FixString(leftOf);
            this.Value = this.FixString(rightOf);

            return true;
        } // FromString

        private string PrepareString(string value) { return value.Replace(Seperator, "%PROPSEPERATOR%"); }

        private string FixString(string value) { return value.Replace("%PROPSEPERATOR%", Seperator); }

        public override void AppendFromData(XINI.EntryItem parentEntry, XINI.AppendModes appendMode)
        {
            if(appendMode == XINI.AppendModes.Read) {
                this.Name = parentEntry.Name;
                this.Value = parentEntry.Value;
            } else if(appendMode == XINI.AppendModes.Save) {
                parentEntry.Name = this.Name;
                parentEntry.Value = this.Value;
            }
        } // AppendFromData

        public override XINI.BaseContainer Clone() { return new PropertyItem(this); }

        public override string EntryName { get { return this.Name; } }
    } // PropertyItem
} // IOLib namespace
