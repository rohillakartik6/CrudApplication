using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.Repository.Interface;
using Assesment_KartikRohilla.Services.Interface;

namespace Assesment_KartikRohilla.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public async Task<List<GetEmployees>> Employees()
        {
            var response = await repo.Get();
            foreach (var data in response)
            {
                var base64 = await ConvertImageToBase64(data.ProfileImage);
                data.ProfileImage = base64;
            }
            return response;
        }


        public async static Task<string> ConvertImageToBase64(string fileName)
        {
            try
            {
                string imagePath = @"Uploads\Employee\" + fileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                //"data:image/"
                string imageExtension = Path.GetExtension(imagePath);

                // Convert byte array to base64 string
                string base64String = Convert.ToBase64String(imageBytes);
                base64String = "data:image/" + imageExtension + ";base64, " + base64String;
                return base64String;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<ApiResponse> AddEmployee(Employees model)
        {
            ApiResponse response = new ApiResponse();
            int data;
            if (model.Row_Id == 0)
            {
                data = await repo.Add(model);
            }
            else
            {
                data = await repo.Update(model);
            }
            if (data > 0)
            {
                response.StatusCode = 201;
                response.Result = data;
                response.Message = "Employee Saved Successfully.";
                response.IsError = false;
            }
            else
            {
                response.IsError = true;
                response.Message = "Something went wrong. Please try again later.";
                response.StatusCode = 400;
            }
            return response;
        }

        public async Task<Employees> GetEmployeeById(int id)
        {
            var data = await repo.GetById(id);
            var base64 = await ConvertImageToBase64(data.ProfileImage);
            data.ProfileImageBase64 = base64;
            return data;
        }

        public async Task<ApiResponse> UploadImage(ProfilePicture model)
        {
            ApiResponse response = new ApiResponse();
            var fileName = await SaveImageToLocal(model.Base64);
            response.Result = new { fileName };
            response.Message = "Image Uploaded Successfully.";
            response.StatusCode = 201;
            response.IsError = false;
            return response;
        }

        public async static Task<string> SaveImageToLocal(string base64)
        {
            byte[] imageBytes = Convert.FromBase64String(base64);
            string fileName = $"{Guid.NewGuid()}.jpg";
            string filePath = Path.Combine("Uploads", "Employee", fileName);
            await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);
            return fileName;
        }

        public async Task<ApiResponse> DeleteEmployee(int id)
        {
            ApiResponse response = new ApiResponse();
            response.Result = await repo.Delete(id);
            response.StatusCode = 203;
            response.Message = "Employee Deleted Successfully.";
            return response;
        }

        public async Task<ApiResponse> CheckDuplicate(string fieldName, string value)
        {
            ApiResponse response = new ApiResponse();
            var data = await repo.CheckDuplicate(fieldName, value);
            if (data == 0)
            {
                response.IsError = false;
                response.StatusCode = 204;
            }
            else
            {
                response.IsError = false;
                response.StatusCode = 409;
            }
            return response;
        }

        public async Task<ApiResponse> DeleteProfileImage(string fileName)
        {

            ApiResponse response = new ApiResponse();
            if (!Guid.TryParse(Path.GetFileNameWithoutExtension(fileName), out _))
            //if (fileName.Length > 50)
            {
                fileName = await repo.GetProfileImageFileName(Convert.ToInt32(fileName));
            }
            var data = await DeleteImageFromLocal(fileName);
            if (data == 204)
            {
                response.StatusCode = 204;
                response.Message = "Image Deleted Successfully.";
                response.IsError = false;
            }
            else
            {
                response.StatusCode = data;
                response.IsError = true;
            }
            return response;
        }

        public async Task<int> DeleteImageFromLocal(string fileName)
        {
            string filePath = Path.Combine("Uploads", "Employee", fileName);
            if (string.IsNullOrEmpty(fileName))
            {
                return 400;
            }
            if (!System.IO.File.Exists(filePath))
            {
                return 404;
            }

            try
            {
                System.IO.File.Delete(filePath);
                return 204;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error deleting file.");
                return 500;
            }
        }
    }
}
