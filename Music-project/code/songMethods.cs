using System.Data;

namespace Music_project.NewFolder
{
    public class songMethods
    {
        DataSet ds = new DataSet("playlist");
        public DataSet GetAllSongs(string file)
        {
           // DataSet ds = new DataSet("playlist");

            DataTable dtSongs = new DataTable("song");

            DataColumn dcId = new DataColumn("id");
            DataColumn dcArtist = new DataColumn("artist");
            DataColumn dcTitle = new DataColumn("title");
            DataColumn dcYear = new DataColumn("year");
            DataColumn dcGenre = new DataColumn("genre");
            DataColumn dcTime = new DataColumn("time");

            dtSongs.Columns.Add(dcId);
            dtSongs.Columns.Add(dcArtist);
            dtSongs.Columns.Add(dcTitle);
            dtSongs.Columns.Add(dcYear);
            dtSongs.Columns.Add(dcGenre);
            dtSongs.Columns.Add(dcTime);

            ds.Tables.Add(dtSongs);
            try
            {
                // ds.ReadXml(Environment.CurrentDirectory + playlist.xml);
            }
            catch
            { }
            return ds;
        }

        public DataRow GetEmptyDataRow()
        {
            DataRow dr = ds.Tables["song"].NewRow();
            return dr;
        }
        public void AddNewRow(DataRow dr)
        {
            ds.Tables["song"].Rows.Add(dr);
            ds.WriteXml(Environment.CurrentDirectory + "/Data/playlist.xml");
        }
    }
}
