using AutoMapper;
using Lab1.Models.UniversityModels;

namespace Lab1.Mappings;

public class StudentProfile:Profile
{
    public StudentProfile()
    {
        CreateMap<Student,StudentViewModel>().
            ForMember(d => d.Age,e=>e.MapFrom(r=>CalculateAge(r.birthdate))).
            ForMember(d=>d.phoneNumber,e=>e.MapFrom(r=>r.phoneNumber)).
            ForMember(d=>d.email,e=>e.MapFrom((r=>r.email))).
            ForMember(d=>d.password,e=>e.MapFrom((_=>"Password!"+DateTime.Now)));

    }
    public static int CalculateAge(DateOnly dateOfBirth)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        int age = today.Year - dateOfBirth.Year;
        if (today < dateOfBirth.AddYears(age))
        {
            age--;
        }

        return age;
    }
}