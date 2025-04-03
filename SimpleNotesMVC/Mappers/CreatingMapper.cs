using AutoMapper;
using SimpleNotesMVC.Database.Models;
using SimpleNotesMVC.Database;
using SimpleNotesMVC.ModelDTOs;

namespace SimpleNotesMVC.Mappers
{
    public class CreatingMapper:Profile
    {
        public CreatingMapper()
        {
            CreateMap<RegisterModelDTO, UserModel>();
            CreateMap<LoginModelDTO, UserModel>();
            CreateMap<UserModel, UserResponseDTO>();
            CreateMap<CreateNoteDTO, NotesModel>();
            CreateMap<NotesModel, NotesResponseDTO>();
        }
    }
}
