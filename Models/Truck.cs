using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioAspNetCore1.Models;

public class CurrentYear : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        try
        {
            int year = Convert.ToInt32(value);
            return year == DateTime.Now.Year;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}

public class CurrentYearOrSubsequent : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        try
        {
            int year = Convert.ToInt32(value);
            int current = DateTime.Now.Year;
            return year >= current && year <= current + 1;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}

public class ModelAllowed : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value != null)
        {
            return value.ToString() == "FH" || value.ToString() == "FM";
        }

        return false;
    }
}

public class Truck
{
    [Display(Name = "ID")] public int ID { get; set; }

    [Required(ErrorMessage = "O campo Modelo é obrigatório")]
    [ModelAllowed(ErrorMessage = "O modelo deve ser do tipo FH ou FM")]
    [Display(Name = "Modelo")]
    public string Model { get; set; }

    [Required(ErrorMessage = "O campo Ano de fabricação é obrigatório")]
    [CurrentYear(ErrorMessage = "O ano de fabricação deve ser igual ao ano atual")]
    [Display(Name = "Ano de fabricação")]
    public int ManufacturingYear { get; set; }

    [Required(ErrorMessage = "O campo Ano do modelo é obrigatório")]
    [CurrentYearOrSubsequent(ErrorMessage = "O ano do modelo deve ser igual ao ano atual ou igual ao ano que vem")]
    [Display(Name = "Ano do modelo")]
    public int ModelYear { get; set; }
}