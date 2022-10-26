using Isu.CustomException;
using Isu.Extra.Exception;
using Isu.Models;

namespace Isu.Extra.Models;

public class MegaFacultyName
{
    private static Dictionary<string, List<FacultyName>> _listMegaFaculty = new Dictionary<string, List<FacultyName>>()
    {
        {
            "CTaM", new List<FacultyName>()
            {
                new FacultyName('N'),
                new FacultyName('D'),
                new FacultyName('K'),
                new FacultyName('P'),
            }
        },
        {
            "PhT", new List<FacultyName>()
            {
                new FacultyName('L'),
                new FacultyName('R'),
            }
        },
        {
            "TInT", new List<FacultyName>()
            {
                new FacultyName('M'),
            }
        },
        {
            "SL", new List<FacultyName>()
            {
                new FacultyName('A'),
                new FacultyName('F'),
            }
        },
    };
    public MegaFacultyName(string name)
    {
        if (!_listMegaFaculty.ContainsKey(name))
            throw MegaFacultyNameException.MegaFacultyIsAbsent(name);
        MegaFaculty = name;
    }

    public string MegaFaculty { get; }

    public static MegaFacultyName CorrelateFaculty(FacultyName facultyName)
    {
        foreach (var megafaculty in _listMegaFaculty)
        {
            var faculty = megafaculty
                .Value
                .Where(i => i.Letter == facultyName.Letter).FirstOrDefault();
            if (faculty != null)
            {
                return new MegaFacultyName(megafaculty.Key);
            }
        }

        throw FacultyNameException.FacultyIsAbsent(facultyName.Letter);
    }
}