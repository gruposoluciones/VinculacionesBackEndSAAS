using System;
using Vinculaciones.Api.common;
using Vinculaciones.Application.common;
using Vinculaciones.Application.interfaces.repositories;

namespace Vinculaciones.Application.usecases.users.ListPesquisasByEstablishmentId;

public class ListPesquisasByEstablishmentIdUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IEstablishmentRepository _establishmentRepository;
    public ListPesquisasByEstablishmentIdUseCase(
        IUserRepository userRepository,
        IEstablishmentRepository establishmentRepository)
    {
        _userRepository = userRepository;
        _establishmentRepository = establishmentRepository;
    }
    public async Task<Result<ListPesquisasByEstablishmentIdResponse>> Execute(int idEstablishment)
    {
        var establishmentExists = await _establishmentRepository.existsById(idEstablishment);
        if (!establishmentExists)
        {
            return Result<ListPesquisasByEstablishmentIdResponse>.
                Fail($"No existe el Establecimiento con id {idEstablishment}", ResultCode.BadRequest);
        }
        var pesquisas = await _userRepository.ListPesquisasByEstablishmentId(idEstablishment);

        return Result<ListPesquisasByEstablishmentIdResponse>.Ok(new ListPesquisasByEstablishmentIdResponse()
        {
            pesquisaUserDto = pesquisas!
        });
    }
}
