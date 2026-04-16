using System;
using Vinculaciones.Api.common;
using Vinculaciones.Application.usecases.users.ListPesquisasByEstablishmentId;

namespace Vinculaciones.Application.gateways.Pesquisas;

public interface IPesquisasGateway
{
    Task<Result<ListPesquisasByEstablishmentIdResponse>> ListPesquisasByEstablishmentId(int idEstablishment);
}
