using Isu.CustomException;
using Isu.Extra.Exception;
using Isu.Models;

namespace Isu.Extra.Models;

public class MegaFaculty
{
    private List<FacultyName> _listFaculty;

    public MegaFaculty(string name, List<FacultyName> listFaculty)
    {
        MegaFacultyName = name;
        _listFaculty = listFaculty;
    }

    public string MegaFacultyName { get; }

    public bool ContainsFaculty(FacultyName faculty)
    {
        if (_listFaculty.FirstOrDefault(i => i.Letter == faculty.Letter) == null)
            return false;
        return true;
    }
}