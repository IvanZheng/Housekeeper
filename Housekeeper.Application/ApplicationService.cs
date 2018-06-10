using Housekeeper.Domain.Repositories;
using IFramework.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Housekeeper.Application
{
    public class ApplicationService
    {
        protected readonly IHousekeeperRepository Repository;
        protected readonly IAppUnitOfWork UnitOfWork;
        protected readonly ILogger Logger;


        public ApplicationService(IHousekeeperRepository repository,
                                  IAppUnitOfWork unitOfWork,
                                  ILogger logger)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
            Logger = logger;
        }
    }
}
