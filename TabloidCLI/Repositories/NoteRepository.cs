using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;
using TabloidCLI.UserInterfaceManagers;

namespace TabloidCLI
{
    public class NoteRepository : DatabaseConnector, IRepository<Note>
    {
        public NoteRepository(string connectionString) : base(connectionString) { }

        public List<Note> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,

                                        Title,
                                        Content, 
                                        CreateDateTime,
                                        PostId 
                                          FROM Note";
                    List<Note> notes = new List<Note>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Note note = new Note()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            PublishDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime")),



                        };
                        notes.Add(note);
                    }

                    reader.Close();

                    return notes;
                }
            }
        }

        public Note Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id AS NoteId,
                                             Title,
                                             Content,
                                             CreateDateTime as PublishDateTime
                                          FROM Note 
                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    Note note = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (note == null)
                        {
                            note = new Note()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("NoteId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                PublishDateTime = reader.GetDateTime(reader.GetOrdinal("PublishDateTime")),


                            };

                        }
                    }

                    reader.Close();

                    return note;
                }
            }
        }

        public void Insert(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Note (Title, Content, CreateDateTime, PostId)
                                                     VALUES (@Title, @Content, @CreateDateTime, @PostId)";
                    cmd.Parameters.AddWithValue("@Title", note.Title);
                    cmd.Parameters.AddWithValue("@Content", note.Content);
                    cmd.Parameters.AddWithValue("@CreateDateTime", note.PublishDateTime);
                    cmd.Parameters.AddWithValue("@PostId", note.Post.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Note 
                                           SET Title = @Title,
                                                Content= @Content,
                                                CreateDateTime= @CreateDateTime,
                                                PostId = @postId
                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@Title", note.Title);
                    cmd.Parameters.AddWithValue("@Content", note.Content);
                    cmd.Parameters.AddWithValue("@CreateDateTime", note.PublishDateTime);
                    cmd.Parameters.AddWithValue("@id", note.Id);
                    cmd.Parameters.AddWithValue("@PostId", note.Post.Id);




                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Note WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}