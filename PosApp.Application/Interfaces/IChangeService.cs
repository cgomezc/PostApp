using PosApp.Application.DTOs;

namespace PosApp.Application.Interfaces
{
    public interface IChangeService
    {
        ChangeResponseDto GetChange(ChangeRequestDto changeRequest);
    }
}
