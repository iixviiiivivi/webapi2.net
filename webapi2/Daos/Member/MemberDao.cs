using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi2.Models;

namespace webapi2.Daos.Member
{
    public class MemberDao : IDao<member>
    {
        private static readonly MemberEntities db = new MemberEntities();

        public List<member> FindAll()
        {
            List<member> members = db.members.ToList();
            return members;
        }

        public member FindOne(int? id)
        {
            if (id is null || id < 0) return null;

            member member = db.members.SingleOrDefault(m => m.id == id);
            if (member != null) return member;

            return null;
        }

        public member Save(member obj)
        {
            if (obj is null) return null;

            db.members.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public member Update(int? id, member obj)
        {
            if (id is null || id < 0 || obj is null) return null;

            obj.id = id.Value;
            member member = db.members.SingleOrDefault(m => m.id == id);
            if (member is null) return null;

            db.Entry(member).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int? id)
        {
            if (id is null || id < 0) return false;

            member member = db.members.SingleOrDefault(m => m.id == id);
            if (member is null) return false;

            db.members.Remove(member);
            db.SaveChanges();
            return true;
        }

    }
}