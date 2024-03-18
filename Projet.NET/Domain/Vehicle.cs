using Shared.ApiModels;
using Shared;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
/*        public Model Model { get; set; }*/

        public int ModelId { get; set; }
        public int Year { get; set; }
        
        private int _mileage;

        public int Mileage
        {
            get => _mileage;
            set
            {
                if (value > 0)
                {
                    _mileage = value;
                }
                else
                {
                    throw new ArgumentException("Le kilométrage doit être un nombre positif ou nul.");
                }
            }
        }

        private string _matriculation;

        public string Matriculation
        {
            get => _matriculation;
            set
            {
                if (value.Length >= 7 && value.Length <= 9)
                {
                    _matriculation = value;
                }
                else
                {
                    throw new ArgumentException("L immatriculation doit avoir entre 7 et 9 caractères");
                }
            }
        }

        public EnergyType Energie { get; set; }
        [JsonIgnore] public IList<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
    }
}
