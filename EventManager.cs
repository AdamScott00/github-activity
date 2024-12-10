using System.Diagnostics;
using github_activity.Model;

namespace github_activity;

record struct ActivitySummary(string Type, string Repo);

public class EventManager
{
    public List<string> GetEventOutputs(List<Event> events)
    {
        List<string> output = new List<string>();
        Dictionary<ActivitySummary, int> summary = new Dictionary<ActivitySummary, int>();
        
        foreach (Event e in events)
        {
            ActivitySummary a = new ActivitySummary(e.Type, e.Repo.Name);
            if (summary.ContainsKey(a))
            {
                summary[a]++;
            }
            else
            {
                summary[a] = 1;
            }
        }

        //See context action for LINQ conversion
        foreach (var activitySummary in summary.Keys)
        {
            output.Add($"- {StringForEventType(activitySummary.Type)} {summary[activitySummary]} time(s) to {activitySummary.Repo}.");
        }
        
        return output;
    }

    public string StringForEventType(string eventType)
    {
        switch (eventType)
        {
            case "CommitCommentEvent":
                return "Committed commit";
            case "CreateEvent":
                return "Created event";
            case "DeleteEvent":
                return "Deleted event";
            case "ForkEvent":
                return "Forked event";
            case "GollumEvent":
                return "Gollum event";
            case "IssueCommentEvent":
                return "Issued event";
            case "IssuesEvent":
                return "Issued event";
            case "MemberEvent":
                return "Member event";
            case "PublicEvent":
                return "Public event";
            case "PullRequestEvent":
                return "Pull request event";
            case "PullRequestReviewEvent":
                return "Pull request review event";
            case "PullRequestReviewCommentEvent":
                return "Pull request review comment event";
            case "PullRequestReviewThreadEvent":
            case "PushEvent":
                return "Pull request review thread event";
            case "ReleaseEvent":
                return "Release event";
            case "SponsorshipEvent":
                return "Sponsorship event";
            case "WatchEvent":
                return "Watched event";
            default:
                return "Unknown event";
        }
    }
}