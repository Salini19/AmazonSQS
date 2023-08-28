using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Models
{

    public class Employee
    {      
        public int Id { get; set; }      
        public string Email { get; set; }
        public string Name { get; set; }
        public string Mobile {get;set;}

    }   
}
