using System;
using System.Collections.Generic;

namespace School_Mang.BL.SITE
{
    public class TableKey
    {
        public int CourseId { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public int TermId { get; set; }

        public TableKey(int c, int g, int s, int t)
        {
            CourseId = c;
            GradeId = g;
            SubjectId = s;
            TermId = t;
        }

        public override bool Equals(object obj)
        {
            var other = obj as TableKey;
            if (other == null) return false;

            return CourseId == other.CourseId &&
                   GradeId == other.GradeId &&
                   SubjectId == other.SubjectId &&
                   TermId == other.TermId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + CourseId.GetHashCode();
                hash = hash * 23 + GradeId.GetHashCode();
                hash = hash * 23 + SubjectId.GetHashCode();
                hash = hash * 23 + TermId.GetHashCode();
                return hash;
            }
        }
    }

    public static class LookupCache
    {
        private static HashSet<TableKey> _courseKeys = new HashSet<TableKey>();

        private static DateTime _expireAt = DateTime.MinValue;

        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);

        private static readonly object _lock = new object();

        // الأعمدة الموحدة (كل الجداول نفس المفتاح)
        public static readonly string[] KeyColumns =
            { "course_id", "grade_id", "subject_id", "term_id" };

        // =========================
        // LOAD (تحميل الكورسات فقط)
        // =========================
        public static void Load(CLS_MANGE_SITE site)
        {
            lock (_lock)
            {
                bool needReload =
                    _courseKeys == null ||
                    _courseKeys.Count == 0 ||
                    _expireAt < DateTime.Now;

                if (!needReload)
                    return;

                _courseKeys = site.GetTableKeys(); // 🔥 الأساس كله هنا
                _expireAt = DateTime.Now.Add(CacheDuration);
            }
        }

        // =========================
        // VALIDATION (واحد بس)
        // =========================
        public static bool IsValidCourse(TableKey key)
        {
            lock (_lock)
            {
                if (_courseKeys == null || _courseKeys.Count == 0)
                    return false;

                if (_expireAt < DateTime.Now)
                    return false;

                return _courseKeys.Contains(key);
            }
        }

        // =========================
        // REFRESH
        // =========================
        public static void Refresh(CLS_MANGE_SITE site)
        {
            lock (_lock)
            {
                _courseKeys = site.GetTableKeys();
                _expireAt = DateTime.Now.Add(CacheDuration);
            }
        }
    }
}