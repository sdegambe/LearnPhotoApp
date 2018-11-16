using System.Collections.Generic;
using System.Threading.Tasks;
using LearnPhotoApp.Models;

namespace LearnPhotoApp.Managers
{
    public interface IPhotoManagerApi
    {
        Task<IEnumerable<Photo>> GetMyPhotos();
        Task<int> InsertPhoto(string fileName);

        Task<bool> PutPhotoToStorage(string photoPath);

    }
}