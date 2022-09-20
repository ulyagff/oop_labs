using System.Collections.ObjectModel;
using Isu.CustomException;
namespace Isu.Models;

public class FacultyName
{
    private ReadOnlyDictionary<char, string> _abbreviations;

    public FacultyName(char letter)
    {
        Dictionary<char, string> abbreviationsTemp = new Dictionary<char, string>()
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
        _abbreviations = new ReadOnlyDictionary<char, string>(abbreviationsTemp);

        char.ToUpper(letter);
        if (!_abbreviations.ContainsKey(letter))
            throw StereotypeIsuException.FacultyIsAbsent(letter);
        Letter = letter;
    }

    public char Letter { get; }
}