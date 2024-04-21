﻿using Vmk.Application.Models.Domain;

namespace Vmk.Application.Contracts;

public interface IDosAndDontsService
{
    Task<List<DoAndDont>?> GatAllAsync(CancellationToken cancellationToken = default);

    Task<List<DoAndDont>?> GetVisibleAsync(CancellationToken cancellationToken = default);
}
