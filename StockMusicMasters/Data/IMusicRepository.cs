using System.Collections.Generic;
using StockMusicMasters.Models;

namespace StockMusicMasters.Data
{
    public interface IMusicRepository
    {
        List<MusicTrack> MusicTracks { get; }
        List<MusicTrack> CurrentMusicTracks { get; set; }
        string CurrentMood { get; set; }
        string CurrentInstrument { get; set; }
        string CurrentGenre { get; set; }
        List<MoodTag> MoodList { get; }
        List<InstrumentTag> InstrumentList { get; }
        List<GenreTag> GenreList { get; }
        void SaveSongToDatabase(MusicTrack musicTrack);
        void UpdateSongInDatabase(MusicTrack musicTrack);
        void DeleteSongFromDatabase(MusicTrack musicTrack);
        void DeleteMusicTrackMoodTags(MusicTrack musicTrack);
        void DeleteMusicTrackInstrumentTags(MusicTrack musicTrack);
        void AddMusicTrack(MusicTrack musicTrack);
        MusicTrack GetMusicTrackById(int id);
        MusicTrack GetMusicTrackByName(string name);
        List<MusicTrack> GetMusicTracksByMood(List<MusicTrack> tracks, string moodSelect);
        List<MusicTrack> GetMusicTracksByInstrument(List<MusicTrack> tracks, string instrumentSelect);
        List<MusicTrack> GetMusicTracksByGenre(List<MusicTrack> tracks, string genreSelect);

        GenreTag GetGenreTagFromDataBase(string genre);
        MoodTag GetMoodTagFromDatabase(string mood);
        InstrumentTag GetInstrumentTagFromDatabase(string instrument);
    }
}
