using System.ComponentModel.DataAnnotations;

namespace Poliza.Models
{
    public class PolicyEntity
    {
       

        public PolicyEntity() { }

        public PolicyEntity(
            int policyNumber,
            string customerName,
            string customerID,
            DateTime customerBirthDay,
            string policyCoverage,
            int policyCoverageValue,
            string policyPlanName,
            string customerCity,
            string customerAddress,
            string vehiclePlate,
            string vehicleModel,
            bool vehicleIsCheked,
            DateTime policyStartDate,
            DateTime policyEndDate
        )
        {
            PolicyNumber = policyNumber;
            CustomerName = customerName;
            CustomerID = customerID;
            CustomerBirthDay = customerBirthDay;
            PolicyCoverage = policyCoverage;
            PolicyCoverageValue = policyCoverageValue;
            PolicyPlanName = policyPlanName;
            CustomerCity = customerCity;
            CustomerAddress = customerAddress;
            VehiclePlate = vehiclePlate;
            VehicleModel = vehicleModel;
            VehicleIsCheked = vehicleIsCheked;
            PolicyStartDate = policyStartDate;
            PolicyEndDate = policyEndDate;
        }

        [Required]
        public long ID { get; set; }

        [Required]
        public int PolicyNumber { get; set; }

        [Required]
        public string CustomerName { get; set; }
       
        [Required]
        public string CustomerID { get; set; }

        [Required]
        public DateTime CustomerBirthDay { get; set; }

        [Required]
        public string PolicyCoverage { get; set; }

        [Required]
        public int PolicyCoverageValue { get; set; }

        [Required]
        public string PolicyPlanName { get; set; }

        [Required]
        public string CustomerCity { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public string VehiclePlate { get; set; }

        [Required]
        public string VehicleModel { get; set; }

        [Required]
        public bool VehicleIsCheked { get; set; }

        [Required]
        public DateTime PolicyStartDate { get; set; }

        [Required]
        public DateTime PolicyEndDate { get; set; }
    }
}

