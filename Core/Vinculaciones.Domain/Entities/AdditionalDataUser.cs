using Vinculaciones.Domain.Entities;

public class AdditionalDataUser
{
    public long Id { get; private set; }
    public long IdUsers { get; private set; }
    public string? PrimerNombre { get; private set; }
    public string? SegundoNombre { get; private set; }
    public string? ApellidoPaterno { get; private set; }
    public string? ApellidoMaterno { get; private set; }
    public DateOnly? FechaNacimiento { get; private set; }
    public long? IdTipoDocIden { get; private set; }
    public string? NroDocIdentidad { get; private set; }
    public string? NroTelefono { get; private set; }

    // Relaciones de navegación
    public User? User { get; private set; }
    public TiposDocIdentidad? TipoDocumento { get; private set; }

    public AdditionalDataUser(long id,
        long idUsers,
        string? primerNombre = null,
        string? segundoNombre = null,
        string? apellidoPaterno = null,
        string? apellidoMaterno = null,
        DateOnly? fechaNacimiento = null,
        long? idTipoDocIden = null,
        string? nroDocIdentidad = null,
        string? nroTelefono = null)
    {
        Id = id;
        IdUsers = idUsers;
        PrimerNombre = primerNombre;
        SegundoNombre = segundoNombre;
        ApellidoPaterno = apellidoPaterno;
        ApellidoMaterno = apellidoMaterno;
        FechaNacimiento = fechaNacimiento;
        IdTipoDocIden = idTipoDocIden;
        NroDocIdentidad = nroDocIdentidad;
        NroTelefono = nroTelefono;
    }

}