using Bloc_De_Notas.AppCore.Interfaces;
using Bloc_De_Notas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bloc_De_Notas.AppCore.Service
{
    public class FileService : BaseService<FileStream>, IFileService
    {
        private IFileRepository fileRepository;

        public FileService(IFileRepository fileRepository) : base(fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public string AbrirArchivo(string path)
        {
            return fileRepository.AbrirArchivo(path);
        }

        public void GuardarArchivo(string ruta, string mensaje)
        {
            fileRepository.GuardarArchivo(ruta, mensaje);
        }
    }
}
