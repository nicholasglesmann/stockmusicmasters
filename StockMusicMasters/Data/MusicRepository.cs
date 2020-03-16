using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMusicMasters.Models;
using Microsoft.EntityFrameworkCore;

namespace StockMusicMasters.Data
{
    public class MusicRepository : IMusicRepository
    {
        private ApplicationDbContext context;

        private static List<MusicTrack> musicTracks = new List<MusicTrack>();

        public List<MusicTrack> MusicTracks { get { return musicTracks; } }

        private static List<MusicTrack> currentMusicTracks = new List<MusicTrack>();

        public List<MusicTrack> CurrentMusicTracks { get { return currentMusicTracks; } set { currentMusicTracks = value; } }

        private static List<MoodTag> moodList = new List<MoodTag>();

        public List<MoodTag> MoodList { get { return moodList; } }

        private static List<InstrumentTag> instrumentList = new List<InstrumentTag>();

        public List<InstrumentTag> InstrumentList { get { return instrumentList; } }

        private static List<GenreTag> genreList = new List<GenreTag>();

        public List<MusicTrackInstrumentTag> MusicTrackInstrumentTags { get { return musicTrackInstrumentTags; } }

        private static List<MusicTrackInstrumentTag> musicTrackInstrumentTags = new List<MusicTrackInstrumentTag>();

        public List<MusicTrackMoodTag> MusicTrackMoodTags { get { return musicTrackMoodTags; } }

        private static List<MusicTrackMoodTag> musicTrackMoodTags = new List<MusicTrackMoodTag>();

        public List<GenreTag> GenreList { get { return genreList; } }

        private static string currentMood = "";

        public string CurrentMood { get { return currentMood; } set { currentMood = value; } }

        private static string currentInstrument = "";

        public string CurrentInstrument { get { return currentInstrument; } set { currentInstrument = value; } }

        private static string currentGenre = "";

        public string CurrentGenre { get { return currentGenre; } set { currentGenre = value; } }

        public MusicRepository(ApplicationDbContext context)
        {
            this.context = context;

            // If MusicTracks is empty, load all data from DB
            if (MusicTracks.Count == 0)
            {
                // load genre/instrument/mood/musicTrack list from db
                genreList.AddRange(context.GenreTags.OrderBy(g => g.Tag).ToList());

                // THE FAST WAY
                moodList.AddRange(context.MoodTags.OrderBy(m => m.Tag).ToList());

                // THE SLOW WAY
                //List<MoodTag> allMoodTags = context.MoodTags.ToList();

                //foreach (MoodTag mt in allMoodTags)
                //{
                //    moodList.Add(mt.Tag);
                //}

                //moodList.Sort();

                instrumentList.AddRange(context.InstrumentTags.OrderBy(i => i.Tag).ToList());

                musicTrackInstrumentTags.AddRange(context.MusicTrackInstrumentTags.ToList());

                musicTrackMoodTags.AddRange(context.MusicTrackMoodTags.ToList());


                musicTracks = context.MusicTracks.Include(m => m.Genre).Include(x => x.MusicTrackMoodTags).Include(x => x.MusicTrackInstrumentTags).ToList();

                foreach (MusicTrack musicTrack in musicTracks)
                {

                    foreach (MusicTrackMoodTag mt in musicTrack.MusicTrackMoodTags)
                    {
                        musicTrack.Moods.Add(MoodList.First(m => m.ID == mt.MoodTagID));
                    }

                    foreach (MusicTrackInstrumentTag it in musicTrack.MusicTrackInstrumentTags)
                    {
                        musicTrack.Instruments.Add(InstrumentList.First(m => m.ID == it.InstrumentTagID));
                    }

                }
            }
        }

        public void RefreshMusicTracks()
        {
            musicTracks = new List<MusicTrack>();

            musicTracks = context.MusicTracks.Include(m => m.Genre).Include(x => x.MusicTrackMoodTags).Include(x => x.MusicTrackInstrumentTags).ToList();

            foreach (MusicTrack musicTrack in musicTracks)
            {

                foreach (MusicTrackMoodTag mt in musicTrack.MusicTrackMoodTags)
                {
                    musicTrack.Moods.Add(MoodList.First(m => m.ID == mt.MoodTagID));
                }

                foreach (MusicTrackInstrumentTag it in musicTrack.MusicTrackInstrumentTags)
                {
                    musicTrack.Instruments.Add(InstrumentList.First(m => m.ID == it.InstrumentTagID));
                }

            }
        }

        public void SaveSongToDatabase(MusicTrack musicTrack)
        {
            context.MusicTracks.Add(musicTrack);
            context.SaveChanges();
            RefreshMusicTracks();
        }

        public void UpdateSongInDatabase(MusicTrack musicTrack)
        {
            context.MusicTracks.Update(musicTrack);
            context.SaveChanges();
            RefreshMusicTracks();
        }

        public void DeleteSongFromDatabase(MusicTrack musicTrack)
        {
            context.MusicTracks.Remove(musicTrack);
            context.SaveChanges();
            RefreshMusicTracks();
        }

        public void DeleteMusicTrackInstrumentTags(MusicTrack musicTrack)
        {
            var tagsToDelete = context.MusicTrackInstrumentTags.Where(m => m.MusicTrackID == musicTrack.ID);
            context.MusicTrackInstrumentTags.RemoveRange(tagsToDelete);
            context.SaveChanges();
        }

        public void DeleteMusicTrackMoodTags(MusicTrack musicTrack)
        {
            var tagsToDelete = context.MusicTrackMoodTags.Where(m => m.MusicTrackID == musicTrack.ID);
            context.MusicTrackMoodTags.RemoveRange(tagsToDelete);
            context.SaveChanges();
        }

        public void AddMusicTrack(MusicTrack musicTrack)
        {
            musicTracks.Add(musicTrack);
        }

        public MusicTrack GetMusicTrackById(int id)
        {
            MusicTrack musicTrack = musicTracks.Find(m => m.ID == id);
            return musicTrack;
        }
        public MusicTrack GetMusicTrackByName(string name)
        {
            MusicTrack musicTrack = musicTracks.Find(m => m.Name == name);
            return musicTrack;
        }

        public List<MusicTrack> GetMusicTracksByMood(List<MusicTrack> tracks, string moodSelect)
        {
            List<MusicTrack> musicTracksByMood = (List<MusicTrack>)tracks.Where(m => m.Moods.Any(mood => mood.Tag == moodSelect)).ToList();
            return musicTracksByMood;
        }

        public List<MusicTrack> GetMusicTracksByInstrument(List<MusicTrack> tracks, string instrumentSelect)
        {
            List<MusicTrack> musicTracksByInstrument = (List<MusicTrack>)tracks.Where(m => m.Instruments.Any(instrument => instrument.Tag == instrumentSelect)).ToList();
            return musicTracksByInstrument;
        }

        public List<MusicTrack> GetMusicTracksByGenre(List<MusicTrack> tracks, string genreSelect)
        {
            List<MusicTrack> musicTrackByGenre = (List<MusicTrack>)tracks.Where(m => m.Genre.Tag == genreSelect).ToList();
            return musicTrackByGenre;
        }

        public GenreTag GetGenreTagFromDataBase(string genre)
        {
            return context.GenreTags.First(g => g.Tag == genre);
        }

        public MoodTag GetMoodTagFromDatabase(string mood)
        {
            return context.MoodTags.First(m => m.Tag == mood);
        }

        public InstrumentTag GetInstrumentTagFromDatabase(string instrument)
        {
            return context.InstrumentTags.First(i => i.Tag == instrument);
        }
    }
}
