using System.ComponentModel.DataAnnotations;

namespace WingsMarket.DTOs.CustomerDTO;
// El DTO se usa para poder realizar consultas creando clases que contengan la informacion de
// forma general. Ej en vez de hacer dos consulta Http realiza una que contenga un DTO con la 
// informacion de las 2 entidades que quiero consultar

//En especial este DTO lo ocupo tambien para mapear un opbjeto que entra a la api para 
public class CustomerDTO{

    [Required]
    [StringLength(100)]
    public required string nameCustomer;
    [Required]
    [StringLength(100)]
    public required string lastNameCustomer;
    [Required]
    [Range(18,100)]
    public required int ageCustomer;
    [Required]
    [EmailAddress]
    public required string emailCustomer;
    [Required]
    [Phone]
    public required string phoneNumberCustomer;
}
// se usa doble requered por que 
// Si deseas asegurar que las propiedades estén siempre inicializadas 
// (en el código y durante la construcción del objeto), usa el modificador required.
// Si quieres asegurarte de que el valor no sea null ni vacío cuando los datos provienen 
// de una solicitud HTTP (por ejemplo, un POST), usa el atributo [Required].