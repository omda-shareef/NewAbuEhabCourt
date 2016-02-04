using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace LowyerDatalayer.Tables_Classes
{
    public class IssueCmd : DataBase
    {
        /// <summary>
        /// Method that Add New Issue 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>True </returns>
        public bool NewIssue(Issue x)
        {
            DbContext.Issues.InsertOnSubmit(x);
            DbContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xIssue"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EditIssue(Issue xIssue, int id)
        {
            xIssue.Id = id;
            var q = CompiledQuery.Compile((DbDataContext db, int issueId) =>
                db.Issues.Single(f => f.Id == issueId));
            var issueEdited = q(DbContext, id);

            issueEdited.AccountId = xIssue.AccountId;
            issueEdited.Attachments = xIssue.Attachments;
            issueEdited.FollowUpIssues = xIssue.FollowUpIssues;
            issueEdited.TheDate = xIssue.TheDate;
            issueEdited.IssueType = xIssue.IssueType;

            DbContext.SubmitChanges();
            return true;
        }
        // Complate Your cODE ok but see 
    }
}
