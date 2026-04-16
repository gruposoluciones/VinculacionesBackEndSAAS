using System;
using Vinculaciones.Api.common;
using Vinculaciones.Application.usecases.users.ListPesquisasByEstablishmentId;

namespace Vinculaciones.Application.gateways.Pesquisas;

public class PesquisasGateway : IPesquisasGateway
{
    private readonly ListPesquisasByEstablishmentIdUseCase _listPesquisasByEstablishmentIdUseCase;
    public PesquisasGateway(ListPesquisasByEstablishmentIdUseCase listPesquisasByEstablishmentIdUseCase)
    {
        _listPesquisasByEstablishmentIdUseCase = listPesquisasByEstablishmentIdUseCase;
    }
    public Task<Result<ListPesquisasByEstablishmentIdResponse>> ListPesquisasByEstablishmentId(int idEstablishment)
    {
        return _listPesquisasByEstablishmentIdUseCase.Execute(idEstablishment);
    }
}
