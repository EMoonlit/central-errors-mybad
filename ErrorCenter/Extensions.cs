using ErrorCenter.Dtos;
using ErrorCenter.Models;

namespace ErrorCenter
{
    public static class Extensions
    {
        public static ErrorDto AsDto(this Error error)
        {
            return new ErrorDto
            {
                Id = error.Id,
                Title = error.Title,
                Description = error.Description,
                Level = error.Level,
                EventsCount = error.EventsCount
            };
        }

        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };
        }
    }
}
