namespace VsProjEdit.Models
{
    class PropsTypeItem
    {
        public string Name { get; set; }

        public NewProjectModel.EPropsType Id { get; set; }

        public PropsTypeItem(string name, NewProjectModel.EPropsType id)
        {
            Name = name;
            Id = id;
        }
    }
}
