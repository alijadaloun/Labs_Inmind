using AutoMapper;
using Lab1.Models.UniversityModels;

namespace Lab1.Mappings;

public class TeacherProfile:Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher,TeacherViewModel>().
            ForMember(d=>d.Name,e=>e.MapFrom(r=>r.Name)).
            ForMember(d=>d.phoneNumber,e=>e.MapFrom(r=>r.phoneNumber)).
            ForMember(d=>d.email,e=>e.MapFrom((r=>r.email))).
            ForMember(d=>d.password,e=>e.MapFrom((_=>"Password!"+DateTime.Now)));

    }
}