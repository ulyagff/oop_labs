using System.Collections.ObjectModel;
using Isu.CustomException;
namespace Isu.Models;

public class FacultyName
{
    private static Dictionary<char, string> _abbreviations = new Dictionary<char, string>()
    {
        { 'A', "ChemBio Cluster" },
        { 'D', "Institute for International Development and Partnership" },
        { 'F', "Institute of Translational Medicine" },
        { 'K', "Infocommunication technologies" },
        { 'L', "Laser photonics" },
        { 'M', "Information technology and programming" },
        { 'N', "Information technology security" },
        { 'P', "Software engineering and computer technology" },
        { 'R', "Control systems and robotics" },
    };

    public FacultyName(char letter)
    {
        char.ToUpper(letter);
        if (!_abbreviations.ContainsKey(letter))
            throw EntitiesNameExceptionFactory.FacultyIsAbsent(letter);
        Letter = letter;
    }

    public char Letter { get; }
}