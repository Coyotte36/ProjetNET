using Shared;
using Shared.ApiModels;

namespace Server.Domain
{
    public class Model
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name; 
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 1)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Le nom du modèle doit avoir au moins 1 caractère");
                }
            }
        }
        public BrandName Brand { get; set; }
        public int MaintenanceFrequency { get; set; }
        public string Description { get; set; }
    }
}
