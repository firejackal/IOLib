/*' Build Version: 19
'
'
' Build 19 - Monday, March 27, 2013
'   * (09:15) Update: Changed more Collections to Lists due to limitations of a Collection.
'   * (09:15) Update: Renamed a few private variables.
'   * (09:15) Update: Internally used functions that was never used outside, are now declared as
'                     //Protected Friend' to prevent outside usage.
'   * (09:15) Update: Entry Class's GetParents() was actually only used when saving a XINI file,
'     some of this function has been coded to reduce new constructors used, but still needs to be reduced
'     to remove the function calling itself and moved over to the saving section.
'   * (09:28) Update: The function //SplitPathName' now supports linux-style path separators.
'   * (09:58) Update: The function //SplitEntryPath' now suppots linux-style path separators, also recoded
'                     the function so it no longer uses a loop to search for the last path nathis.
'   * (10:02) Bugfix: Found a mistype in SetEntryValue() where when adding a new entry, it would of not
'                     set the correct entry nathis.
'   * (10:06) Update: ParserDesc was unneeded as it only housed a instance to the ParsedEntriesCollection,
'                     replaced all references with that class instead of ParserDesc.
'   * (10:12) New:    Added support to read from a stream.
'   * (10:31) Update: Recoded SplitParsedLines() a little bit, needs testing.
'
' Build 18 - Saturday, February 9th, 2013
'   * (08:18) Update: Changed the base collection of BaseCollectionContainer and BaseCollectionContainer2
'     over to Generic.List instead of List because Generic.List is faster and supports
'     the Sort() function.
'
' Build 17 - Tuesday, February 2nd, 2010
'   * (19:53) New:    Added two new overloaded classes, BaseContainer, and
'     BaseCollectionContainer, these two classes can be used for databases for the same
'     code doesn't have to be kept re-writing foreach(class.
'
' Build 16 - Wednesday, December 10th, 2008
'   * (00:24) Update: Updated the file methods to use the .net version instead of the
'     visual basic alternative for this can be supported in the compact .net framework.
'
' Build 15 - Wednesday, October 15th, 2008
'   * (18:30) New:    Added some more AppendChildEntryValue overload functions.
'   * (18:30) New:    Added an AppendChildEntryEnumValue overload function.
'   * (18:30) Update: Changed default value support for the AppendChildEntryValue
'     functions to failbackDefault and savingDefault from default.
'
' Build 14 - Monday, May 5th, 2008
'   * (18:48) New:    Added the SaveToFile() overload function that takes no arguments,
'     this command will save to the file that was last opened.
'   * (19:51) New:    Added the function //Entries_EnumChildren()' that will return all
'     an entry's children entry indexes.
' 
' Build 13 - Wednesday, April 16th, 2008
'   * (20:00) New:    Added a new New() operator supporting a file name argument for a
'     file can be loaded right off the bat.
'   * (21:26) New:    Added integer overload support for AppendChildEntryValue().
'
' Build 12 - Tuesday, April 15th, 2008
'   * (20:04) Update: Ported the XINI class module over to
'     VisualBasic.NET, this new version needs extensive testing.
'   * (20:04) Note:   Porting included using Visual Studio 2003's
'     built-in VB6 to VB.net upgrade wizard, and changing all
'     found arrays to accept the 0 to X-1 base instead of 1 to X
'     since VB.net does not allow 1 to X. The code that only needs
'     to be converted to make this backwards compatible with anyone
'     currently familier with the XINI SDK, is the internal collection
'     of arrays only, all numbers passed to functions needs to be
'     remained as the 1 to X base.
'
' Build 11 - Tuesday, February 19th, 2008
'   * (20:50) Update: To improve database speed, after a database has
'     been loaded, a function called //FixEntryIndexes()' is called that
'     makes sure all parent and children indexes are correct.
'     But this breaks as soon as the caller manually removes an entry.
'     But if(the caller never removed any entries and instead just
'     //reads' from it, then this improvement will make a difference,
'     the reason why this does upon loading the database is because
'     there is an internal removal of some entries on loading.
'
' Build 10 - Thursday, January 31st, 2008
'   * (19:27) Update: To improve database speed, now when a entry's
'     parent ID is stored, the parent's entry index is also stored,
'     and this entry index is automaticly detected if(changed, and if
'     it's changed (IDs do not match) then it's fixed.
'   * (19:30) New:    Added the function //Entries_AddWithParentIndex()'
'     to help improve performance when a entry is trying to be added
'     that had it's parent index available.
'   * (19:34) Update: Replaced all of the old code to use the
'     //Entries_AddWithParentIndex()' function now to improve
'     performance.
'   * (19:47) Update: Entries children now are stored by entry ID, and
'     entry Index, and the same method used to improve database speed
'     with finding an entry's parent has been merged into the children
'     code as well.
'
' Build 9 - Tuesday, January 22nd, 2008
'   * (18:04) New: Added the function //AppendChildEntryValue()' to cut
'     user code down.
'
' Build 8 - Saturday, January 5th, 2008
'   * (10:23) Now the functions //SetEntryValue', //SetChildEntryValue',
'     and //SetChildEntryValue2' support default properties, if(the
'     value being set is the same as the default value then the
'     property won't be saved.
'
' Build 7 - Sunday, December 30th, 2007
'   * (02:28) Added code to fix incoming and outgoing text for an
'     entry's name and value.
'     What the code looks for is the [ and ] characters since these
'     would cause parsing problems if(saved into entry text, these
'     two characters are replaced with %91 and %93 when the text is
'     incoming, when the text is outgoing, it replaces it back with
'     with the [ and ] characters.
'
' Build 6 - Sunday, December 23rd, 2007
'   * (20:43) Added support to prevent duplication of IDs, but this
'     will be slower to open files now.
'
' Build 5 - Wednesday, December 19th, 2007
'   * (21:23) Found a bug where the unique-ID was generated for the
'     same entry more then once if(there was a lot of entries, this
'     was replaced with a 128-bit random generator, which was found
'     to have the same bug, but worse... so right now using 129-bits
'     seem to work.
'
' Build 4 - Sunday, December 16th, 2007
'   * (21:16) The version key is no longer used by XINI,
'     now can be used by anything that uses this class, it goes along
'     with the name key, it's up to the developer how to use it.
'
' Build 3 - Tuesday, November 6th, 2007
'   * (19:23) Fixed a bug in the procedure //SetChildEntryValue()'
'     where it wasn't adding a new entry when the child wasn't found.
'   * (20:59) Because VB isn't too friendly with recursive functions
'     after so many times it ran, I replaced the saving code with a
'     built-in psuedo recursive method, which seems to work.
'
' Build 2 - Thursday, November 1st, 2007
'   * (18:47) Found a bug where duplicated entries actually did not work
'     at all... Starting to implement a new system to control parent and
'     children entries.
'   * (21:18) Parent paths are now removed, everything works off of
'     parent and children entry data using IDs.
'
' Build 1
'   * Created.
*/

/*' Testing:
'   * As of version 12, version 12 is VB.NET support, testing must start over from scratch.
'   * (2008/04/16 - 19:58) Reading and saving files testing and working.
'   * (2008/04/16 - 19:58) Using GetEntryValue() and SetEntryValue() tested and working.
'   * (2008/04/16 - 21:10) Using AppendEntry() and AppendChildEntryValue() tested and working for saving.
'   * (2013/05/27 - 09:15) A bug was noted where a XINI file was saved with entry values containing the
'     filtered [ and ] characters. When used as a name or value, this breaks XINI parsing and was suppose
'     to be converted to/from as a special number, somehow this passed it. The only possible reason is that
'     the [ and ] characters stored, was unicode instead of a character.
'
' Notes:
'   * Since using VB.NET, new features can be added, for an example; overloading functions.
*/

//Option Strict Off
//Option Explicit On

using System.Collections.Generic;

namespace IOLib
{
    public class XINI
    {
        public enum AppendModes
        {
            Read,
            Save
        }//AppendModes

    #region "Objects"
        ///<summary>Holds information about a key.</summary>
        ///<remarks>Also holds which key is it's parent, and which keys are it's children.</remarks>
        public class EntryItem
        {
            private string mName  = "";
            private string mValue = "";
            private List<EntryItem> mChildren = new List<EntryItem>();
            public  EntryItem Parent;

            protected internal EntryItem() { }
            protected internal EntryItem(EntryItem parent, string name, string value) { this.Name = name; this.Value = value; this.Parent = parent; }

            /// <summary>The key's nathis.</summary>
            /// <value>The key's new name, does not have to be unique.</value>
            /// <returns>Returns the key's nathis.</returns>
            /// <remarks>Handled here because of special character detection.</remarks>
            public string Name
            {
                get { return FixValueOutgoing(this.mName); }
                set { this.mName = FixValueIncoming(value); }
            } //Name

            /// <summary>The key's value.</summary>
            /// <value>The value used by the key. Does not have to contain anything.</value>
            /// <returns>Returns the key's value.</returns>
            /// <remarks>This procedure is used in order to identify special cases.</remarks>
            public string Value
            {
                get { return FixValueOutgoing(this.mValue); }
                set { this.mValue = FixValueIncoming(value); }
            } //Value

    #region "Saving Support"
            // TODO: Move the code from GetParents() into GetParentsCount(), adding a loop for recurrence, then move function to saving code.
            private void GetParents(List<EntryItem> theList)
            {
                // Prepare the output list.
                if(theList == null) theList = new List<EntryItem>();
                // if(this is the root or a level next to the root (the root is considered null.)
                if(this.Parent == null || this.Parent.Parent == null) return;
                // Add this parent to the list.
                theList.Add(this.Parent);
                // Add the parent's parents to the list.
                this.Parent.GetParents(theList);
            } //GetParents

            protected internal int GetParentsCount()
            {
                List<EntryItem> parents = new List<EntryItem>();
                this.GetParents(parents);

                if(parents == null) {
                    return 0;
                } else {
                    return parents.Count;
                }
            } //GetParentsCount
    #endregion //Saving Support

    #region "Children"
            public List<EntryItem> Children { get { return this.mChildren; } }

            public EntryItem AddChild(string name, string value = "")
            {
                this.mChildren.Add(new EntryItem(this, name, value));
                return this.mChildren[this.mChildren.Count - 1];
            } //AddChild

            public bool HasChild(string childName) { return this.FindChildIndex(childName) >= 0; }

            public EntryItem GetChildEntry(string childName)
            {
                int index = this.FindChildIndex(childName);
                if(index < 0)
                    return null;
                else
                    return this.mChildren[index];
            } //GetChildEntry

            protected internal int FindChildIndex(string name)
            {
                if(this.mChildren.Count > 0) {
                    for(int index = 0; index < this.mChildren.Count; index++) {
                        if(string.Equals(this.mChildren[index].Name, name, System.StringComparison.CurrentCultureIgnoreCase)) return index;
                    } //index
                }

                return -1;
            } //FindChildIndex

            public string GetChildValue(string name, string defaultValue = "")
            {
                int childIndex = this.FindChildIndex(name);
                if(childIndex < 0) return defaultValue;
                return this.mChildren[childIndex].Value;
            } //GetChildValue

            public void SetChildValue(string name, string value)
            {
                int childIndex = this.FindChildIndex(name);
                if(childIndex < 0)
                    this.AddChild(name, value);
                else
                    this.mChildren[childIndex].Value = value;
            } //GetChildValue

            public int GetChildValueInteger(string name, int defaultValue = 0)
            {
                int childIndex = this.FindChildIndex(name);
                if(childIndex < 0) return defaultValue;
                return this.mChildren[childIndex].ValueInteger;
            } //ChildValueInteger

            public void SetChildValue(string name, int value)
            {
                int childIndex = this.FindChildIndex(name);
                if(childIndex < 0)
                    this.AddChild(name, value.ToString());
                else
                    this.mChildren[childIndex].ValueInteger = value;
            } //ChildValueInteger

            public byte GetChildValueByte(string name, byte defaultValue = 0)
            {
                int childIndex = this.FindChildIndex(name);
                if(childIndex < 0) return defaultValue;
                return this.mChildren[childIndex].ValueByte;
            } //ChildValueInteger

            public void SetChildValue(string name, byte value)
            {
                int childIndex = this.FindChildIndex(name);
                if(childIndex < 0 )
                    this.AddChild(name, value.ToString());
                else
                    this.mChildren[childIndex].ValueByte = value;
            } //ChildValueInteger

            public long GetChildValueLong(string name, long defaultValue = 0)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0) return defaultValue;
                    return this.mChildren[childIndex].ValueLong;
            } //ChildValueLong

            public void SetChildValue(string name, long value)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0)
                        this.AddChild(name, value.ToString());
                    else
                        this.mChildren[childIndex].ValueLong = value;
            } //ChildValueLong

            public bool GetChildValueBoolean(string name, bool defaultValue = false)
            {
                int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0) return defaultValue;
                    return this.mChildren[childIndex].ValueBool;
            } //ChildValueBoolean

            public void SetChildValue(string name, bool value)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0)
                        this.AddChild(name, value.ToString());
                    else
                        this.mChildren[childIndex].ValueBool = value;
            } //ChildValueBoolean

            public float GetChildValueSingle(string name, float defaultValue = 0.0f)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0) return defaultValue;
                    return this.mChildren[childIndex].ValueSingle;
            } //ChildValueSingle

            public void SetChildValue(string name, float value)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0)
                        this.AddChild(name, value.ToString());
                    else
                        this.mChildren[childIndex].ValueSingle = value;
            } //ChildValueSingle

            public double GetChildValueDouble(string name, double defaultValue = 0.0)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0) return defaultValue;
                    return this.mChildren[childIndex].ValueDouble;
            } //ChildValueDouble

            public void SetChildValue(string name, double value)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0)
                        this.AddChild(name, value.ToString());
                    else
                        this.mChildren[childIndex].ValueDouble = value;
            } //ChildValueDouble

            public decimal GetChildValueDecimal(string name, decimal defaultValue = 0.0m)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0) return defaultValue;
                    return this.mChildren[childIndex].ValueDecimal;
            } //ChildValueDecimal

            public void SetChildValue(string name, decimal value)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0)
                        this.AddChild(name, value.ToString());
                    else
                        this.mChildren[childIndex].ValueDecimal = value;
            } //ChildValueDecimal

            public TEnum GetChildValueEnumerate<TEnum>(string name, string defaultValue = "") where TEnum : struct
            {
                int childIndex = this.FindChildIndex(name);

                defaultValue = defaultValue.Replace(" ", "");
                if(childIndex < 0) {
                    TEnum results; System.Enum.TryParse<TEnum>(defaultValue, out results);
                    return results;
                } else {
                    return this.mChildren[childIndex].GetValueEnumerate<TEnum>(defaultValue);
                }
            } //ChildValueEnumerate

            public void SetChildValue(string name, System.Enum value)
            {
                    int childIndex = this.FindChildIndex(name);
                    if(childIndex < 0)
                        this.AddChild(name, value.ToString());
                    else
                        this.mChildren[childIndex].SetValue(value);
            } //ChildValueEnumerate

            public T GetChildValue<T>(string name, ValueParseHandler<T> parse, string defaultValue = "")
            {
                int childIndex = this.FindChildIndex(name);

                //defaultValue = defaultValue.Replace(" ", "");
                if(childIndex < 0) return parse(defaultValue, typeof(T));

                return this.mChildren[childIndex].GetValue<T>(parse, defaultValue);
            } //ChildValueEnumerate

            public void SetChildValue<T>(string name, T value)
            {
                int childIndex = this.FindChildIndex(name);
                if(childIndex < 0)
                    this.AddChild(name, value.ToString());
                else
                    this.mChildren[childIndex].SetValue<T>(value);
            } //ChildValueEnumerate

            //public EntryObject GetChildValueObject(string name, EntryObject baseType, string defaultValue = "")
            //{
            //    int childIndex = this.FindChildIndex(name);

            //    defaultValue = defaultValue.Replace(" ", "");
            //    if(childIndex < 0) return (System.Enum)System.Enum.Parse(type, defaultValue);

            //    return this.mChildren[childIndex].GetValueEnumerate(type, defaultValue);
            //} //ChildValueEnumerate

            //public void SetChildValue(string name, EntryObject value)
            //{
            //    int childIndex = this.FindChildIndex(name);
            //    if(childIndex < 0)
            //        this.AddChild(name, value.ToString());
            //    else
            //        this.mChildren[childIndex].SetValue(value);
            //} //ChildValueEnumerate

            public EntryItem AppendChildEntry(string name, AppendModes appendMode)
            {
                int entryIndex = this.FindChildIndex(name);

                if(appendMode == AppendModes.Read) {
                    if(entryIndex >= 0) return this.mChildren[entryIndex];
                } else if(appendMode == AppendModes.Save) {
                    if(entryIndex < 0)
                        return this.AddChild(name);
                    else
                        return this.mChildren[entryIndex];
                }

                return null;
            } //AppendChildEntry

            public bool AppendChildEntryValue(string childName, ref string value, AppendModes appendMode, string fallbackDefault = "", string savingDefault = "", bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read) {
                    value = this.GetChildValue(childName, fallbackDefault);
                    return true;
                } else if(appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref long value, AppendModes appendMode, long fallbackDefault = 0, long savingDefault = 0, bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read) {
                    value = this.GetChildValueLong(childName, fallbackDefault);
                    return true;
                } else if(appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref int value, AppendModes appendMode, int fallbackDefault = 0, int savingDefault = 0, bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read) {
                    value = this.GetChildValueInteger(childName, fallbackDefault);
                    return true;
                } else if(appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref bool value, AppendModes appendMode, bool fallbackDefault = false, bool savingDefault = false, bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read ) {
                    value = this.GetChildValueBoolean(childName, fallbackDefault);
                    return true;
                } else if( appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref float value, AppendModes appendMode, float fallbackDefault = 0.0F, float savingDefault = 0.0F, bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read ) {
                    value = this.GetChildValueSingle(childName, fallbackDefault);
                    return true;
                } else if( appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref double value, AppendModes appendMode, double fallbackDefault = 0.0, double savingDefault = 0.0, bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read) {
                    value = this.GetChildValueDouble(childName, fallbackDefault);
                    return true;
                } else if(appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref decimal value, AppendModes appendMode, decimal fallbackDefault = 0m, decimal savingDefault = 0m, bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read) {
                    value = this.GetChildValueDecimal(childName, fallbackDefault);
                    return true;
                } else if(appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref System.DateTime value, AppendModes appendMode, string fallbackDefault = "01/01/2000", string savingDefault = "01/01/2000")
            {
                if(appendMode == AppendModes.Read) {
                    EntryItem childEntry = this.AppendChildEntry(childName, appendMode);
                    if(childEntry == null) {
                        System.DateTime dateDefault;
                        if(System.DateTime.TryParse(savingDefault, out dateDefault)) value = dateDefault;
                    } else {
                        int month  = childEntry.GetChildValueInteger("Month");
                        int day    = childEntry.GetChildValueInteger("Day");
                        int year   = childEntry.GetChildValueInteger("Year");
                        int hour   = childEntry.GetChildValueInteger("Hour");
                        int minute = childEntry.GetChildValueInteger("Minute");
                        int sec    = childEntry.GetChildValueInteger("Second");
                        int milli  = childEntry.GetChildValueInteger("Millisecond");
                        value = new System.DateTime(year, month, day, hour, minute, sec, milli);
                    }

                    return true;
                } else if(appendMode == AppendModes.Save) {
                    System.DateTime dateDefault;
                    if(System.DateTime.TryParse(savingDefault, out dateDefault)) {
                        if(value == dateDefault) return true;
                    }

                    EntryItem childEntry = this.AppendChildEntry(childName, appendMode);
                    if(childEntry != null ) {
                        childEntry.SetChildValue("Month", value.Month);
                        childEntry.SetChildValue("Day", value.Day);
                        childEntry.SetChildValue("Year", value.Year);
                        childEntry.SetChildValue("Hour", value.Hour);
                        childEntry.SetChildValue("Minute", value.Minute);
                        childEntry.SetChildValue("Second", value.Second);
                        childEntry.SetChildValue("Millisecond", value.Millisecond);
                    }

                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryValue(string childName, ref byte value, AppendModes appendMode, byte fallbackDefault = 0, byte savingDefault = 0, bool ignoreSavingDefault = false)
            {
                if(appendMode == AppendModes.Read) {
                    value = this.GetChildValueByte(childName, fallbackDefault);
                    return true;
                } else if(appendMode == AppendModes.Save) {
                    if(!ignoreSavingDefault && value == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            public bool AppendChildEntryEnumValue<TEnum>(string childName, ref TEnum value, AppendModes appendMode, string fallbackDefault = "", string savingDefault = "") where TEnum : struct
            {
                if(appendMode == AppendModes.Read)
                {
                    value = this.GetChildValueEnumerate<TEnum>(childName, fallbackDefault);
                    return true;
                }
                else if(appendMode == AppendModes.Save)
                {
                    if(value.ToString() == savingDefault) return true;
                    this.SetChildValue(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryEnumValue

            public bool AppendChildEntryValue<T>(string childName, ref T value, AppendModes appendMode, ValueParseHandler<T> parse, string fallbackDefault = "", string savingDefault = "")
            {
                if(appendMode == AppendModes.Read)
                {
                    value = this.GetChildValue<T>(childName, parse, fallbackDefault);
                    return true;
                }
                else if(appendMode == AppendModes.Save)
                {
                    if(value.ToString() == savingDefault) return true;
                    this.SetChildValue<T>(childName, value);
                    return true;
                }

                return false;
            } //AppendChildEntryValue

            //public bool AppendChildEntryValue(string childName, ref EntryObject value, AppendModes appendMode, string fallbackDefault = "", string savingDefault = "")
            //{
            //    if(appendMode == AppendModes.Read)
            //    {
            //        value = this.GetChildValueEnumerate(childName, value.GetType(), fallbackDefault);
            //        return true;
            //    }
            //    else if(appendMode == AppendModes.Save)
            //    {
            //        if(value.ToString() == savingDefault) return true;
            //        this.SetChildValue(childName, value);
            //        return true;
            //    }

            //    return false;
            //} //AppendChildEntryEnumValue
    #endregion //Children

    #region "Value"
            public int ValueInteger
            {
                get {
                    try {
                        if(string.IsNullOrEmpty(this.Value)) return 0;
                        return System.Convert.ToInt32(this.Value);
                    } catch { //(System.Exception e) {
                        return default(int);
                    }
                }
                set {
                    this.Value = value.ToString();
                }
            } //ValueInteger

            public byte ValueByte
            {
                get {
                    try {
                        if(string.IsNullOrEmpty(this.Value)) return 0;
                        return System.Convert.ToByte(this.Value);
                    } catch { //(System.Exception e) {
                        return default(byte);
                    }
                }
                set {
                    this.Value = value.ToString();
                }
            } //ValueByte

            public long ValueLong
            {
                get {
                    try {
                        if(string.IsNullOrEmpty(this.Value)) return 0L;
                        return System.Convert.ToInt64(this.Value);
                    } catch { //(System.Exception e) {
                        return default(long);
                    }
                }
                set {
                    this.Value = value.ToString();
                }
            } //ValueLong

            public bool ValueBool
            {
                get {
                    try {
                        if(string.IsNullOrEmpty(this.Value)) return false;
                        return System.Convert.ToBoolean(this.Value);
                    } catch { //(System.Exception e) {
                        return default(bool);
                    }
                }
                set {
                    this.Value = value.ToString();
                }
            } //ValueBool

            public float ValueSingle
            {
                get {
                    try {
                        if(string.IsNullOrEmpty(this.Value)) return 0.0F;
                        return System.Convert.ToSingle(this.Value);
                    } catch { //(System.Exception e) {
                        return default(float);
                    }
                }
                set {
                    this.Value = value.ToString();
                }
            } //ValueSingle

            public double ValueDouble
            {
                get {
                    try {
                        if(string.IsNullOrEmpty(this.Value)) return 0.0;
                        return System.Convert.ToDouble(this.Value);
                    } catch { //(System.Exception e) {
                        return default(double);
                    }
                }
                set {
                    this.Value = value.ToString();
                }
            } //ValueDouble

            public decimal ValueDecimal
            {
                get {
                    try {
                        if(string.IsNullOrEmpty(this.Value)) return 0m;
                        return System.Convert.ToDecimal(this.Value);
                    } catch { //(System.Exception e) {
                        return default(decimal);
                    }
                }
                set {
                    this.Value = value.ToString();
                }
            } //ValueDecimal

            public System.Enum GetValueEnumerate(System.Type enumType, string defaultValue = "")
            {
                string entryValue = this.Value;
                entryValue   = entryValue.Replace(" ", "");
                defaultValue = defaultValue.Replace(" ", "");

                try {
                    return (System.Enum)System.Enum.Parse(enumType, entryValue, true);
                } catch { //(System.Exception ex) {
                    try {
                        return (System.Enum)System.Enum.Parse(enumType, defaultValue, true);
                    } catch { //(System.Exception ex2) {
                        return default(System.Enum); //eek! default value is not a valid name!
                    }
                }
            } //ValueEnumerate

            public TEnum GetValueEnumerate<TEnum>(string defaultValue = "") where TEnum : struct
            {
                string entryValue = this.Value;
                entryValue   = entryValue.Replace(" ", "");
                defaultValue = defaultValue.Replace(" ", "");

                try {
                    TEnum results;
                    System.Enum.TryParse<TEnum>(entryValue, out results);
                    return results;
                } catch { //(System.Exception ex) {
                    try {
                        TEnum results;
                        System.Enum.TryParse<TEnum>(defaultValue, out results);
                        return results;
                    } catch { //(System.Exception ex2) {
                        return default(TEnum); //eek! default value is not a valid name!
                    }
                }
            } //ValueEnumerate

            public void SetValue(System.Enum value) { this.Value = value.ToString(); }

            public delegate T ValueParseHandler<T>(string value, System.Type type);

            public T GetValue<T>(ValueParseHandler<T> parse, string defaultValue = "")
            {
                string entryValue = this.Value;
                //entryValue = entryValue.Replace(" ", "");
                //defaultValue = defaultValue.Replace(" ", "");

                try {
                    return (T)parse(entryValue, typeof(T));
                } catch {
                    try {
                        return (T)parse(defaultValue, typeof(T));
                    } catch {
                        return default(T); //eek! default value is not a valid name!
                    }
                }
            } //ValueEnumerate

            public void SetValue<T>(T value) { this.Value = value.ToString(); }
    #endregion //Value
        } //EntryItem
    #endregion //Structures

    #region "Variables"
        private string mFileName      = "";
        private string mHeaderName    = "";
        private string mHeaderVersion = "1";
        private EntryItem mRoot = new EntryItem();
    #endregion //Variables

        public XINI() { this.CloseFile(); }

        public XINI(string fileName)
        {
            this.CloseFile();
            this.LoadFromFile(fileName);
        } //New

        public string FileName
        {
            get {
                return this.mFileName;
            }
            set {
                this.mFileName = value;
            }
        } //FileName

        public string Name
        {
            get {
                return this.mHeaderName;
            }
            set {
                this.mHeaderName = value;
            }
        } //Name

        public string Version
        {
            get {
                return this.mHeaderVersion;
            }
            set {
                this.mHeaderVersion = value;
            }
        } //Version

        public EntryItem Root
        {
            get {
                return this.mRoot;
            }
        } //Root

        public void CloseFile()
        {
            // Clear the stored file nathis.
            this.mFileName      = "";
            this.mHeaderVersion = "1";
            this.mHeaderName    = "";

            // Setup the root.
            this.mRoot.Name  = "Root";
            this.mRoot.Value = "";

            // Clear existing children.
            this.mRoot.Children.Clear();
        } //CloseFile

    #region "Path Entries"
        /// <summary>Given [x\y\z] it will return x, y, and z in an array.</summary>
        private static string[] SplitPathName(string pathName)
        {
            // Don't allow surrounding spaces.
            pathName = pathName.Trim();
            // Convert path separators, should reduce lookups.
            if(pathName.Contains("/")) pathName = pathName.Replace("/", "\\");
            // Don't allow trailing path seperators on the nathis.
            if(pathName.StartsWith("\\")) pathName = pathName.Substring(1);
            if(pathName.EndsWith("\\")) pathName = pathName.Substring(0, pathName.Length - 1);

            if(!pathName.Contains("\\"))
                return new string[] {pathName};
            else
                return pathName.Split('\\');
        } //SplitPathName

        /// <summary>Splits an entry path (E.G. A\B\C) into name and parent strings Name=C, Parent=A\B</summary>
        private static void SplitEntryPath(string inPath, out string outName, out string outParent)
        {
            // TODO: make sure changes work.
            outName   = "";
            outParent = "";

            // Don't allow surrounding spaces.
            inPath = inPath.Trim();
            // Convert path separators, should reduce lookups.
            if(inPath.Contains("/")) inPath = inPath.Replace("/", "\\");
            // Don't allow trailing path seperators on the nathis.
            if(inPath.StartsWith("\\")) inPath = inPath.Substring(1);
            if(inPath.EndsWith("\\")) inPath = inPath.Substring(0, inPath.Length - 1);

            if(!inPath.Contains("\\"))
                outName = inPath;
            else {
                // Find the last path seperator.
                int lastSepIndex = inPath.LastIndexOf("\\");

                // return name everything after the seperator.
                outName   = inPath.Substring(lastSepIndex + 1);
                // return path/parent everything before the seperator.
                outParent = inPath.Substring(0, lastSepIndex);
            }
        } //SplitEntryPath

        /// <summary>Given the entry path [X\Y\Z], it will return what Z//s entry is.</summary>
        public EntryItem GetEntry(string pathName)
        {
            return this.GetEntry(pathName, false);
        } //GetEntry

        private EntryItem GetEntry(string pathName, bool makePath)
        {
            if(string.IsNullOrEmpty(pathName)) return this.mRoot;

            // First let's split the path name up into an array.
            string[] strEntry = SplitPathName(pathName);
            // if(no entries was parsed then ... exit this procedure.
            if(strEntry == null || strEntry.Length == 0) return null;

            EntryItem rootEntry = this.mRoot;

            EntryItem childEntry = null;
            for(int entryIndex = 0; entryIndex <= strEntry.GetUpperBound(0); entryIndex++) {
                childEntry = rootEntry.GetChildEntry(strEntry[entryIndex]);
                if(childEntry == null ) {
                    if(!makePath)
                        return null;
                    else
                        childEntry = rootEntry.AddChild(strEntry[entryIndex]);
                }

                rootEntry = childEntry; //This child is now the next root.
            } //entryIndex

            // When we get done, the last child entry will be the one we want.
            return childEntry;
        } //GetEntry

        public string GetEntryValue(string pathName, string defaultValue = "")
        {
            EntryItem entry = this.GetEntry(pathName);
            if(entry == null) return defaultValue;

            string strValue = entry.Value;
            if(strValue == null) strValue = defaultValue;

            return strValue;
        } //GetEntryValue

        public bool SetEntryValue(string pathName, string value, string defaultValue = "")
        {
            if(value == defaultValue) return true;

            // Make sure the entries path exists ...
            EntryItem entry = this.GetEntry(pathName);
            if(entry == null) {
                // Split up the name ...
                string strParent = ""; string strName = "";
                SplitEntryPath(pathName, out strName, out strParent);

                EntryItem lastEntry = this.GetEntry(strParent, true);
                if(lastEntry == null) return false;

                return (lastEntry.AddChild(strName, value) != null);
            } else
                entry.Value = value;

            return true;
        } //SetEntryValue

        public bool RemoveEntry(string pathName)
        {
            EntryItem entry = this.GetEntry(pathName);
            if(entry == null || entry.Parent == null) return false;
            return entry.Parent.Children.Remove(entry);
        } //RemoveEntry
    #endregion //Path Entries

    #region "Helper Functions"
        private static string FixValueIncoming(string value)
        {
            if(string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim())) return "";
            string results =   value.Replace("[", "%91");
                   results = results.Replace("]", "%93");
            return results;
        } //FixValueIncoming
    
        private static string FixValueOutgoing(string value)
        {
            if(string.IsNullOrEmpty(value.Trim())) return "";
            string results =   value.Replace("%91", "[");
                   results = results.Replace("%93", "]");
            return results;
        } //FixValueOutgoing
    #endregion //Helper Functions

    #region "File Management"
        private class ParserEntriesCollection : List<EntryItem>
        {
            public int PushEntry(EntryItem entry)
            {
                base.Add(entry);
                return (base.Count - 1);
            } //PushEntry

            public bool PopEntry()
            {
                if(base.Count == 0) return false;
                base.RemoveAt(base.Count - 1);
                return true;
            } //PopEntry

            public EntryItem Back()
            {
                if(base.Count > 0)
                    return base[base.Count - 1];
                else
                    return null;
            } //GetLastEntry
        } //ParserEntriesCollection

        public bool LoadFromFile(string fileName)
        {
            // if(the file does not exist then ... exit this procedure.
            if(!System.IO.File.Exists(fileName)) return false;

            // Get access to the file via a stream.
            System.IO.StreamReader oRead = System.IO.File.OpenText(fileName);
            // Parse the data from the stream.
            bool success = this.LoadFromStream(oRead);
            // Close access to the stream.
            oRead.Close();

            // Store the file nathis.
            this.mFileName = fileName;

            // return success or not.
            return success;
        } //LoadFromFile

        public bool LoadFromStream(System.IO.Stream stream)
        {
            using(System.IO.StreamReader newStream = new System.IO.StreamReader(stream)) {
                return this.LoadFromStream(newStream);
            }
        } //LoadFromStream

        public bool LoadFromStream(System.IO.StreamReader stream)
        {
            // if(the file does not exist then ... exit this procedure.
            if(stream == null) return false;

            // Close the file if(it's opened.
            this.CloseFile();

            // Prepare the parser.
            ParserEntriesCollection parserEntries = new ParserEntriesCollection();
            parserEntries.Add(this.mRoot);

            // Read each line from the stream.
            while(stream.Peek() != -1) {
                // Read a line from the stream, and parse it.
                ParseFileLine(FixLineForParsing(stream.ReadLine()), parserEntries);
            }

            // Parse global settings from the read data.
            this.LoadFromFile_ParseGlobalSettings();

            // return successful.
            return true;
        } //LoadFromStream

        private static void ParseFileLine(string line, ParserEntriesCollection parserEntries)
        {
            if(string.IsNullOrEmpty(line)) return;

            bool inEntryHeader = false;
            string tempText = "";

            for(int position = 1; position <= line.Length; position++) {
                string strChar = line.Substring(position - 1, 1);

                if(!inEntryHeader) {
                    if(string.Equals(strChar, "[")) {
                        if(tempText.Length > 0) {
                            if(parserEntries.Count > 0) {
                                string strOldValue = parserEntries.Back().Value;
                                parserEntries.Back().Value = ((string.IsNullOrEmpty(strOldValue)) ? "" : strOldValue + "\n") + tempText;
                            }
                            tempText = "";
                        }

                        inEntryHeader = true;
                    } else
                        tempText += strChar;
                } else if(inEntryHeader) {
                    if(string.Equals(strChar, "]")) {
                        tempText = tempText.Trim();

                        if(tempText.StartsWith("/"))
                            parserEntries.PopEntry();
                        else {
                            bool singleLine = false;
                            if(tempText.EndsWith("/")) {
                                tempText = tempText.Substring(0, tempText.Length - 1).Trim();
                                singleLine = true;
                            }

                            EntryItem entry = parserEntries.Back().AddChild(tempText);
                            if(!singleLine) parserEntries.PushEntry(entry);
                        }
                        // Clear the section nathis.
                        tempText = "";
                        inEntryHeader = false;
                    } else
                        tempText += strChar;
                }
            } //dwPos

            if(tempText.Length > 0) {
                if(parserEntries.Count > 0) {
                    string strOldValue = parserEntries.Back().Value;
                    parserEntries.Back().Value = ((string.IsNullOrEmpty(strOldValue)) ? "" : strOldValue + "\n") + tempText;
                }
                tempText = "";
            }
        } //ParseFileLine

        private static string FixLineForParsing(string line) { return Parser_RemoveTabs(line).Trim(); }

        private static void SplitParsedLines(string data, out int outLinesCount, out string[] outLine)
        {
            outLinesCount = 0;
            outLine       = null;

            if(string.IsNullOrEmpty(data)) return;

            outLine = data.Split('\n');
            if(outLine == null || outLine.Length == 0)
                outLinesCount = 0;
            else
                outLinesCount = outLine.Length;

            /*int charIndex;
            do while(true) {
                charIndex = data.IndexOf("\n");
                //MsgBox "New Line Found at Position (" + charIndex + ")"
                if(charIndex < 0) break;

                outLinesCount += 1;
                ReDim Preserve outLine(outLinesCount - 1);

                outLine[outLinesCount - 1] = data.Substring(0, charIndex);
                //MsgBox "The new Line: " + outLine(outLinesCount - 1)

                data = data.Substring(charIndex + "\n".Length);
                //MsgBox "The new Data: " + data
            }

            if(!string.IsNullOrEmpty(data)) {
                outLinesCount += 1;
                ReDim Preserve outLine(outLinesCount - 1);
                outLine[outLinesCount - 1] = data;
            }*/
        } //SplitParsedLines

        private static string Parser_RemoveTabs(string STR)
        {
            // if(the string is empty then ... exit this procedure.
            if(string.IsNullOrEmpty(STR)) return "";
        
            string strTemp   = "";
            bool   inQuote  = false;

            // Go through each character in the string ...
            string strChar;
            for(int position = 0; position < STR.Length; position++) {
                strChar = STR.Substring(position, 1);

                if(strChar == "\"") {
                    inQuote = !inQuote;
                    strTemp += strChar;
                } else if(strChar == "\t" && !inQuote)
                    strTemp += "";
                else
                    strTemp += strChar;
            } //outString

            return strTemp;
        }

        private void LoadFromFile_ParseGlobalSettings()
        {
            EntryItem parentEntry = this.mRoot.GetChildEntry("XINI");
            if(parentEntry == null) return;

            EntryItem childEntry = parentEntry.GetChildEntry("VERSION");
            if(childEntry == null)
                this.mHeaderVersion = "1";
            else
                this.mHeaderVersion = childEntry.Value;

            childEntry = parentEntry.GetChildEntry("NAME");
            if(childEntry == null)
                this.mHeaderName = "";
            else
                this.mHeaderName = childEntry.Value;

            // Remove the //XNI' entry.
            this.mRoot.Children.Remove(parentEntry);
        } //LoadFromFile_ParseGlobalSettings

        public bool SaveToFile() { return SaveToFile(this.mFileName); }
    
        public bool SaveToFile(string fileName)
        {
            if(string.IsNullOrEmpty(fileName)) return false;

            // Erase or create the file.
            System.IO.StreamWriter oWrite = System.IO.File.CreateText(fileName);

            oWrite.WriteLine("[XINI]");
            oWrite.WriteLine("\t" + "[Name]" + mHeaderName + "[/]");
            oWrite.WriteLine("\t" + "[Version]" + mHeaderVersion + "[/]");
            oWrite.WriteLine("[/]");
            oWrite.WriteLine("");

            // Save the entries, starting at the root level.
            this.SaveToFile_Entries(oWrite);

            // Close the opened file we was writing to.
            oWrite.Close();

            // return successful.
            return true;
        } //SaveToFile

        private void SaveToFile_Entry_NoChildren(System.IO.StreamWriter file, EntryItem entry, bool addNewLineFirst = false)
        {
            int    dwParents = entry.GetParentsCount();
            string strTabs   = new string('\t', dwParents);
            string strName   = entry.Name;
            string strValue  = entry.Value;
            if(strValue == null) strValue = "";
        
            if(addNewLineFirst) file.WriteLine(strTabs + "");

            // if(this entry has no value then ...
            if(strValue.Length == 0)
                file.WriteLine(strTabs + "[" + strName + "/]");
                // if(this entry has a value then ...
            else {
                // ... if(the value has multiple lines then ...
                if(strValue.Contains("\n")) { //InStr(1, strValue, vbLf) || InStr(1, strValue, vbCr)) {
                    file.WriteLine(strTabs + "[" + strName + "]");
                    this.SaveToFile_Entry_MutliLineValue(file, dwParents, strValue);
                    file.WriteLine(strTabs + "[/]");
                    // ... if(the value has one line then ...
                } else
                    file.WriteLine(strTabs + "[" + strName + "]" + strValue + "[/]");
            }
        } //SaveToFile_Entry_NoChildren

        private void SaveToFile_Entry_End(System.IO.StreamWriter file, EntryItem entry)
        {
            int parentCount = entry.GetParentsCount();
            string strTabs  = new string('\t', parentCount);
            string strValue = entry.Value;

            this.SaveToFile_Entry_MutliLineValue(file, parentCount, strValue);
            file.WriteLine(strTabs + "[/]");
        } //SaveToFile_Entry_End

        private void SaveToFile_Entry_MutliLineValue(System.IO.StreamWriter file, int parentsCount, string value)
        {
            if(string.IsNullOrEmpty(value)) return;

            string strTabs = new string('\n', parentsCount);

            int dwLines;
            string[] strLine = null;
            SplitParsedLines(value, out dwLines, out strLine);

            if(dwLines == 1)
                file.WriteLine(strTabs + value);
            else if(dwLines > 1) {
                for(int line = 0; line < dwLines; line++) {
                    file.WriteLine(strTabs + strLine[line]);
                }
            }
        } //SaveToFile_Entry_MutliLineValue

        private void SaveToFile_Entry_Start(System.IO.StreamWriter file, EntryItem entry, bool addNewLineFirst = false)
        {
            int parentCount = entry.GetParentsCount();
            string strTabs = new string('\t', parentCount);
            string strName = entry.Name;

            if(addNewLineFirst) file.WriteLine(strTabs + "");
            file.WriteLine(strTabs + "[" + strName + "]");
        } //SaveToFile_Entry_Start

        private void SaveToFile_Entry(System.IO.StreamWriter file, EntryItem entry)
        {
            if(entry.Children.Count == 0)
                this.SaveToFile_Entry_NoChildren(file, entry, false);
            else {
                this.SaveToFile_Entry_Start(file, entry, false);
                this.SaveToFile_Children(file, entry);
                this.SaveToFile_Entry_End(file, entry);
            }
        } //SaveToFile_Entry

        private void SaveToFile_Children(System.IO.StreamWriter file, EntryItem entry)
        {
            bool first = true;
            EntryItem lastEntry = null;
            foreach(EntryItem child in entry.Children) {
                if(!first) {
                    if(lastEntry == null || lastEntry.Children.Count != 0) {
                        int parentCount = entry.GetParentsCount();
                        string strTabs = new string('\t', parentCount);
                        file.WriteLine(strTabs + "");
                    }
                } else
                    first = false;

                SaveToFile_Entry(file, child);

                lastEntry = child;
            } //child
        } //SaveToFile_Entries

        /// <summary>Goes through every entry with a parent.</summary>
        /// private void SaveToFile_Entries(ByVal hFile As Short)
        private void SaveToFile_Entries(System.IO.StreamWriter file)
        {
            if(this.mRoot.Children.Count == 0) return;
            this.SaveToFile_Children(file, this.mRoot);
        } //SaveToFile_Entries
    #endregion //File Management

    #region "Base Containers"
        //interface EntryObject
        //{
        //    void FromString(string value);
        //    string ToString();
        //}

        public interface BaseContainerInterface
        {
            string EntryName { get; }
            bool LoadFromFile(string fileName);
            bool SaveToFile(string fileName);
            void AppendFromData(EntryItem parentEntry, AppendModes appendMode);
            string FileName { get; set; }
            //void CloneTo<T>(T item) where T : BaseContainerInterface;
        } //BaseContainerInterface

        public abstract class BaseContainer : BaseContainerInterface
        {
            protected string mFileName = "";

            public abstract string EntryName { get; }
            public abstract void AppendFromData(EntryItem parentEntry, AppendModes appendMode);
            //public abstract void CloneTo(BaseContainer item);
            public abstract BaseContainer Clone();

            public virtual bool LoadFromFile(string fileName)
            {
                XINI cXINI = new XINI();
                if(!cXINI.LoadFromFile(fileName)) return false;

                this.mFileName = fileName;

                EntryItem parentEntry = null;
                if(string.IsNullOrEmpty(this.EntryName)) {
                    parentEntry = cXINI.Root;
                } else {
                    parentEntry = cXINI.Root.AppendChildEntry(this.EntryName, AppendModes.Read);
                }
                
                //TODO: maybe of parentEntry is null, then call a virtual function called Defaults() ?
                this.AppendFromData(parentEntry, AppendModes.Read);

                return true;
            } //LoadFromFile

            public virtual bool SaveToFile(string fileName)
            {
                XINI cXINI = new XINI();
                cXINI.Name    = this.EntryName;
                cXINI.Version = "1";

                EntryItem parentEntry = cXINI.Root.AppendChildEntry(this.EntryName, AppendModes.Save);
                this.AppendFromData(parentEntry, AppendModes.Save);

                return cXINI.SaveToFile(fileName);
            } //SaveToFile

            public string FileName
            {
                get { return this.mFileName; }
                set { this.mFileName = value; }
            } //FileName
        } //BaseContainer

        public abstract class BaseCollectionContainer<T> : List<T>, BaseContainerInterface where T : BaseContainer
        {
            protected string mFileName = "";

            public virtual bool LoadFromFile(string fileName)
            {
                XINI cXINI = new XINI();
                if(!cXINI.LoadFromFile(fileName)) return false;

                this.mFileName = fileName;
                EntryItem parentEntry = cXINI.Root;
                if(string.IsNullOrEmpty(this.EntryName)) parentEntry = cXINI.Root.AppendChildEntry(this.EntryName, AppendModes.Read);
                this.AppendFromData(cXINI.Root, AppendModes.Read);

                return true;
            } //LoadFromFile

            public virtual bool SaveToFile(string fileName)
            {
                XINI cXINI = new XINI();
                cXINI.Name    = "Collection Data";
                cXINI.Version = "1";

                EntryItem parentEntry = cXINI.Root;
                if(string.IsNullOrEmpty(this.EntryName)) parentEntry = cXINI.Root.AppendChildEntry(this.EntryName, AppendModes.Save);
                this.AppendFromData(cXINI.Root, AppendModes.Save);

                if(!cXINI.SaveToFile(fileName)) return false;
                return true;
            } //SaveToFile

            public virtual void AppendFromData(EntryItem parentEntry, AppendModes appendMode)
            {
                this.AppendFromData(parentEntry, appendMode, false);
            } //AppendFromData

            public virtual void AppendFromData(EntryItem parentEntry, AppendModes appendMode, bool noChecks)
            {
                if(appendMode == AppendModes.Read) {
                    if(parentEntry.Children.Count > 0) {
                        foreach(EntryItem childEntry in parentEntry.Children) {
                            //T item = this.CreateNewItem();
                            T item = System.Activator.CreateInstance<T>();
                            if(item != null) {
                                if(noChecks || string.Equals(childEntry.Name, item.EntryName, System.StringComparison.CurrentCultureIgnoreCase)) {
                                    item.AppendFromData(childEntry, appendMode);
                                    this.Add(item);
                                }
                            }
                        } //childEntry
                    }
                } else if(appendMode == AppendModes.Save) {
                    if(base.Count > 0) {
                        for(int index = 0; index < this.Count; index++) {
                            EntryItem childEntry = parentEntry.AddChild(this[index].EntryName);
                            this[index].AppendFromData(childEntry, appendMode);
                        } //index
                    }
                }
            } //AppendFromData

            public virtual void CloneTo(BaseCollectionContainer<T> target)
            {
                target.Clear();
                if(this.Count != 0) {
                    for(int index = 0; index < this.Count; index++) {
                        //T item = System.Activator.CreateInstance<T>();
                        //this[index].CloneTo(item);
                        //target.Add(item);
                        target.Add((T)this[index].Clone());
                    } //index
                }
            } //Clone

            public virtual string EntryName { get { return ""; } }

            public string FileName
            {
                get { return this.mFileName; }
                set { this.mFileName = value; }
            } //FileName
        } //BaseCollectionContainer

        public abstract class BaseCollectionContainer2<T> : List<T> where T : BaseContainer
        {
            protected string mFileName = "";

            protected abstract bool IsEntryNameValid(string name);
            protected abstract T CreateItem(string name);
            protected abstract string Name();

            public virtual bool LoadFromFile(string fileName)
            {
                XINI cXINI = new XINI();
                if(!cXINI.LoadFromFile(fileName)) return false;

                this.mFileName = fileName;
                this.AppendFromData(cXINI.Root, AppendModes.Read);

                return true;
            } //LoadFromFile

            public virtual bool SaveToFile(string fileName)
            {
                XINI cXINI = new XINI();
                cXINI.Name    = this.Name();
                cXINI.Version = "1";

                this.AppendFromData(cXINI.Root, AppendModes.Save);

                if(!cXINI.SaveToFile(fileName)) return false;
                return true;
            } //SaveToFile

            public virtual void AppendFromData(EntryItem parentEntry, AppendModes appendMode)
            {
                if(parentEntry == null) return;

                if(appendMode == AppendModes.Read) {
                    if(parentEntry.Children.Count > 0) {
                        foreach(EntryItem childEntry in parentEntry.Children) {
                            if(this.IsEntryNameValid(childEntry.Name) ) {
                                T item = this.CreateItem(childEntry.Name);
                                item.AppendFromData(childEntry, appendMode);
                                this.Add(item);
                            }
                        } //childEntry
                    }
                } else if(appendMode == AppendModes.Save) {
                    if(base.Count > 0) {
                        for(int index = 0; index < this.Count; index++) {
                            EntryItem childEntry = parentEntry.AddChild(this[index].EntryName);
                            this[index].AppendFromData(childEntry, appendMode);
                        } //index
                    }
                }
            } //AppendFromData

            public virtual void CloneTo(BaseCollectionContainer2<T> target)
            {
                target.Clear();
                if(this.Count != 0) {
                    for(int index = 0; index < this.Count; index++) {
                        //T item = System.Activator.CreateInstance<T>();
                        //this[index].CloneTo<T>(item);
                        //target.Add(item);
                        target.Add((T)this[index].Clone());
                    } //index
                }
            } //Clone

            public string FileName
            {
                get { return this.mFileName; }
                set { this.mFileName = value; }
            } //FileName
    } //BaseCollectionContainer2 class
    #endregion //Base Containers region
    } //XINI class
} //IOLib namespace
