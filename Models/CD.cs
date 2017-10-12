using System;
using System.Collections.Generic;

namespace CDOrganizer.Models
{
  public class CD
  {
    private string _albumName;
    private int _year;
    private int _id;
    private static List<CD> _instances = new List<CD> {};

    public CD (string albumName, int year)
    {
      _albumName = albumName;
      _year = year;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetAlbumName()
    {
      return _albumName;
    }

    public void SetAlbumName(string newAlbumName)
    {
      _albumName = newAlbumName;
    }

    public int GetYear()
    {
      return _year;
    }

    public void SetYear(int newYear)
    {
      _year = newYear;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<CD> GetAll()
    {
      return _instances;
    }

    public static CD Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
