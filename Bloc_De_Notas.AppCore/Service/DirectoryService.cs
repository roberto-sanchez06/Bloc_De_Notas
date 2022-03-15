using Bloc_De_Notas.AppCore.Interfaces;
using Bloc_De_Notas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.AppCore.Service
{
    public class DirectoryService: BaseService<DirectoryInfo>, IDirectoryService
    {
        private IDirectoryRepository directoryRepository;

        public DirectoryService(IDirectoryRepository directoryRepository) : base(directoryRepository)
        {
            this.directoryRepository = directoryRepository;
        }
    }
}
