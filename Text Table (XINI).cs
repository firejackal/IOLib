/*
 * Version: Build 5
 *
 * Version Build 5 - Tuesday, May 13th, 2014
 *   - (11:11) Update: Converted over to C# and removed binary code.
 * 
 * Version Build 4 - Thursday, December 9th, 2010
 *   - (15:18) Update: Converted over to managed code and cleaned up code.
 * 
 * Version Build 3 - Monday, March 17th, 2008
 *   - (20:37) Found a bug in the procedure 'TextTableDB_GetValue()' that
 *     it didn't return the correct default value when a entry wasn't
 *     found, this was fixed.
 * 
 * Version Build 2 - Friday, December 14th, 2007
 *   - (18:15) Planning to add to this version:
 *     - Backwards Compatiblity with the Text Table binary files.
 *     - Support using XINI for storing the text table data.
 * 
 * Version Build 1 - Friday, December 14th, 2007
 *   - (18:14) Created from the database code in the SSTools modules.
 * 
 * Requirements:
 *   - XINI.cs
*/

namespace IOLib.TextTable
{
    public class TextTableDatabase : XINI.BaseContainer
    {
	    private TextTableLinesCollection mLines = new TextTableLinesCollection();

	    public TextTableDatabase() {}

	    public TextTableDatabase(string fileName) { this.LoadFromFile(fileName); }

        public TextTableDatabase(TextTableDatabase clone)
        {
            if(clone == null) return;
            this.FileName = clone.FileName;
            this.mLines = new TextTableLinesCollection(clone.mLines);
        } //Constructor

	    public string GetValue(string name, string def = "")
        {
		    int index = this.mLines.FindIndex(name);
		    if(index < 0) return def;
		    return this.mLines[index].Value;
	    } //GetValue function

        public override void AppendFromData(XINI.EntryItem parentEntry, XINI.AppendModes appendMode)
        {
            this.mLines.AppendFromData(parentEntry, appendMode);
        } //AppendFromData function

        public TextTableLinesCollection Lines { get { return this.mLines; } }

        public override string EntryName { get { return "Text Table"; } }

        public override XINI.BaseContainer Clone() { return new TextTableDatabase(this); }
    } //TextTableDatabase class

    public class TextTableLinesCollection : XINI.BaseCollectionContainer<TextTableLineItem>
    {
        public TextTableLinesCollection() {}

        public TextTableLinesCollection(TextTableLinesCollection clone)
        {
            if(clone == null || clone.Count == 0) return;

            for(int index = 0; index < clone.Count; index++) {
                base.Add(new TextTableLineItem(clone[index]));
            } //for index
        } //Constructor

		public TextTableLineItem Add(string name, string value)
        {
			base.Add(new TextTableLineItem(name, value));
			return base[base.Count - 1];
		} //Add function

		public int FindIndex(string name)
        {
			if(base.Count > 0) {
				for(int index = 0; index < base.Count; index++) {
					if(string.Equals(base[index].Name, name, System.StringComparison.CurrentCultureIgnoreCase)) return index;
				} //for index
			}

			return -1;
		} //FindIndex

		public int FindIndexByValue(string value)
        {
			if(base.Count > 0) {
				for(int index = 0; index < base.Count; index++) {
					if(string.Equals(base[index].Value, value, System.StringComparison.CurrentCultureIgnoreCase)) return index;
				} //for index
            }

			return -1;
		} //FindByValue

        /// <summary>Swaps two items in the collection.</summary>
        /// <param name="firstIndex">The first item's index to swap. 1-based.</param>
        /// <param name="secondIndex">The second item's index to swap. 1-based.</param>
        /// <returns>Returns true if successful, false if not.</returns>
		public bool Swap(int firstIndex, int secondIndex)
        {
			if(firstIndex < 1 || firstIndex > base.Count || secondIndex < 1 || secondIndex > base.Count) return false;

			TextTableLineItem oldItem = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = oldItem;

			return true;
		} //Move function

		public override void AppendFromData(XINI.EntryItem parentEntry, XINI.AppendModes appendMode)
        {
            if (parentEntry == null) return;
			if(appendMode == XINI.AppendModes.Read) {
				if(parentEntry.Children.Count > 0) {
					foreach(XINI.EntryItem childEntry in parentEntry.Children) {
						this.Add(childEntry.Name, childEntry.Value);
					} //for childEntry
				}
			} else if(appendMode == XINI.AppendModes.Save) {
				if(base.Count > 0) {
					for(int index = 0; index < base.Count; index++) {
						parentEntry.AddChild(base[index].Name, base[index].Value);
					} //for index
				}
			}
		} //AppendFromData function
	} //TextTableLinesCollection class

	public class TextTableLineItem : XINI.BaseContainer
    {
		public string Name  = "";
		public string Value = "";

		public TextTableLineItem() {}

		public TextTableLineItem(string name, string value)
        {
			this.Name = name;
			this.Value = value;
		} //Constructor

        public TextTableLineItem(TextTableLineItem clone)
        {
            if(clone == null) return;
            this.Name = clone.Name;
            this.Value = clone.Value;
        } //Constructor

		public override void AppendFromData(XINI.EntryItem parentEntry, XINI.AppendModes appendMode)
        {
            parentEntry.AppendChildEntryValue("Name",  ref this.Name, appendMode);
            parentEntry.AppendChildEntryValue("Value", ref this.Value, appendMode);
		} //AppendFromData function

        public override string EntryName { get { return "Item"; } }

        public override XINI.BaseContainer Clone() { return new TextTableLineItem(this); }
    } //TextTableLineItem class
} // IOLib.TextTable namespace
