using System.Data;

namespace Music_project.NewFolder
{
    public class songMethods
    {
        public DataSet GetAllSongs(string file)
        {
            DataSet ds = new DataSet("playlist");

            DataTable dtSongs = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcYear = new DataColumn("year");
            DataColumn dcGenre = new DataColumn("genre");
            DataColumn dcTime = new DataColumn("time");

        }
    }
}
