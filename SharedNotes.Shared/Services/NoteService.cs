using Microsoft.EntityFrameworkCore;
using SharedNotes.Shared.Data;
using SharedNotes.Shared.Entities;

namespace SharedNotes.Shared.Services
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;

        public NoteService(DataContext context)
        {
            _context = context;
        }

        public async Task<Note> AddNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<bool> DeleteNote(int id)
        {
            var dbNote = await _context.Notes.FindAsync(id);
            if(dbNote != null)
            {
                _context.Remove(dbNote);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Note> EditNote(int id, Note note)
        {
            var dbNote = await _context.Notes.FindAsync(id);
            if(dbNote != null)
            {
                dbNote.Title = note.Title;
                await _context.SaveChangesAsync();
                return dbNote;
            }
            throw new Exception("Note not found");
        }

        public async Task<List<Note>> GetAllNotes()
        {
            var notes = await _context.Notes.ToListAsync();
            return notes;
        }

        public async Task<Note> GetNoteById(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task<List<Note>> SearchNote(string term)
        {            
            return await _context.Notes.Where(note => note.Title.Contains(term) || (note.Content != null && note.Content.Contains(term))).ToListAsync();
        }
    }
}
