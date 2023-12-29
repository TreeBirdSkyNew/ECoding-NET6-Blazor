namespace E_CODING_MVC_NET6_0.Models
{
    public class Category
    {
        public string Name { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public List<string> Data { get; set; }

        public Category(string name, Category parent = null)
        {
            Name = name;
            Parent = parent;
            Children = new List<Category>();
            Data = new List<string>();
            if (parent != null)
            {
                parent.Children.Add(this);
            }
        }

        public void AddData(string data)
        {
            Data.Add(data);
        }

        public void RemoveData(string data)
        {
            Data.Remove(data);
        }

        public void RemoveAllData()
        {
            Data.Clear();
        }

        public void AddChild(Category child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public void RemoveChild(Category child)
        {
            Children.Remove(child);
            child.Parent = null;
        }

        public void RemoveAllChildren()
        {
            foreach (Category child in Children)
            {
                child.Parent = null;
            }
            Children.Clear();
        }

        public List<string> GetAllData()
        {
            List<string> allData = new List<string>(Data);
            foreach (Category child in Children)
            {
                allData.AddRange(child.GetAllData());
            }
            return allData;
        }

        public List<string> GetDataForCategory(string categoryName)
        {
            if (Name == categoryName)
            {
                return GetAllData();
            }
            foreach (Category child in Children)
            {
                List<string> data = child.GetDataForCategory(categoryName);
                if (data.Count > 0)
                {
                    return data;
                }
            }
            return new List<string>();
        }
    }
}