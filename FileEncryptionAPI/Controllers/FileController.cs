
using System.Net;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileData _fileData;
        private readonly IUserData _userData;

        public FileController(IFileData fileData, IUserData userData)
        {
            _fileData = fileData;
            _userData = userData;
        }

        // GET: api/file
        [HttpGet]
        public async Task<APIResponse<List<FileModel>>> GetAllFiles()
        {
            try
            {
                var files = await _fileData.GetAllFiles();
                return new APIResponse<List<FileModel>>(files, "Retrieved all files successfully.");
            }
            catch (Exception ex)
            {
                return new APIResponse<List<FileModel>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
            }
        }

        // GET: api/file/5
        [HttpGet("{id}")]
        public async Task<APIResponse<FileModel>> GetFileById(string id)
        {
            try
            {
                var file = await _fileData.GetFile(id);
                if (file == null)
                {
                    return new APIResponse<FileModel>(HttpStatusCode.NotFound, "File not found.");
                }
                return new APIResponse<FileModel>(file, "File retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new APIResponse<FileModel>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
            }
        }

        // POST: api/file
        [HttpPost]
        public async Task<APIResponse<FileResponseDTO>> CreateProduct([FromBody] FileDTO file, string userId)
        {
            if (!ModelState.IsValid)
            {
                return new APIResponse<FileResponseDTO>(HttpStatusCode.BadRequest, "Invalid data", ModelState);
            }

            try
            {
                var user = await _userData.GetUser(userId);
                FileModel fileModel = new()
                {
                    FileName = file.FileName,
                    EncryptedFile = file.EncryptedFile,
                    UploadedBy = new BasicUserModel(user) 
                };
                await _fileData.CreateFile(fileModel);
                var responseDTO = new FileResponseDTO { Status = "success" };
                return new APIResponse<FileResponseDTO>(responseDTO, "File created successfully.");
            }
            catch (Exception ex)
            {
                return new APIResponse<FileResponseDTO>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
            }
        }


        // DELETE: api/file/5
        [HttpDelete("{id}")]
        //public async Task<APIResponse<bool>> DeleteFile(int id)
        //{
        //    //try
        //    //{
        //    //    var product = await _productRepository.GetProductByIdAsync(id);
        //    //    if (product == null)
        //    //    {
        //    //        return new APIResponse<bool>(HttpStatusCode.NotFound, "Product not found.");
        //    //    }

        //    //    await _productRepository.DeleteProductAsync(id);
        //    //    return new APIResponse<bool>(true, "Product deleted successfully.");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return new APIResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        //    //}
        //}
    }
}