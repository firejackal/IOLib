using System.Collections.Generic;

namespace IOLib
{
    public abstract class BaseObjectDatabaseCollection<T> : XINI.BaseCollectionContainer<T> where T : BaseObjectDatabaseItem
    {
        public T Add(string fileName)
        {
            T item = System.Activator.CreateInstance<T>();
            if(item == null || !item.LoadFromFile(fileName)) return null;

            base.Add(item);
            return base[base.Count - 1];
        } //Add

        public void AddFromPath(string pathName)
        {
            List<string> foundFiles = FileSystem.GetDirectoryFiles(pathName, "*." + this.FileExtension().ToLower(), true);
            if(foundFiles != null && foundFiles.Count > 0) {
                foreach(string foundFile in foundFiles) {
                    base.LoadFromFile(foundFile);
                } //foundFile
            }
        } //AddFromPath

        public int IndexOf(string id)
        {
            if(base.Count > 0) {
                for(int index = 0; index < base.Count; index++) {
                    if (string.Equals(base[index].ID, id, System.StringComparison.CurrentCultureIgnoreCase)) return index;
                } //index
            }

            return -1;
        } //IndexOf

        public T this[string id]
        {
            get {
                int index = this.IndexOf(id);
                if(index < 0) return null;
                return base[index];
            }
        } //Item

        public abstract string FileExtension();
    } //BaseObjectDatabaseCollection

    public abstract class BaseObjectDatabaseItem : XINI.BaseContainer
    {
        public string ID = "";

        public BaseObjectDatabaseItem() {}

        public BaseObjectDatabaseItem(string fileName) { base.LoadFromFile(fileName); }
    } // BaseObjectDatabaseItem
} // IOLib namespace
