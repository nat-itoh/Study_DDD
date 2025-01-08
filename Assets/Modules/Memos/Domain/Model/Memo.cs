using System;
using System.Collections.Generic;
using Project.Domain.Shared;

namespace Project.Domain.Memos.Model {

    /// <summary>
    /// ������\��Entity�D
    /// </summary>
    public class Memo : EntityBase<Guid> {

        public string Title { get; private set; }

        public Content Content { get; private set; }

        public List<Tag> Tags { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public Memo(Guid id, string title, Content content) : base(id){
            Title = title;
            Content = content;
            Tags = new List<Tag>();
        }

        public void UpdateTitle(string title) {
            Title = title;
        }

        public void UpdateContent(Content content) {
            Content = content;
        }

        /// <summary>
        /// �^�O��ǉ�����D
        /// </summary>
        public void AddTag(Tag tag) {
            if (!Tags.Contains(tag)) {
                Tags.Add(tag);
            }
        }

        /// <summary>
        /// �^�O���폜����D
        /// </summary>
        public void RemoveTag(Tag tag) {
            Tags.Remove(tag);
        }
    }
}
