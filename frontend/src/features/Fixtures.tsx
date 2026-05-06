import { useMemo, useState } from "react";
import { Link } from "react-router";

const FILTERS = ["All", "Live", "Upcoming", "Finished"] as const;

export type Match = {
  id: string;
  date: string;
  time: string;
  stage: string;
  group?: string;
  home: string;
  homeFlag: string;
  away: string;
  awayFlag: string;
  city: string;
  stadium: string;
  status: "upcoming" | "live" | "finished";
  homeScore?: number;
  awayScore?: number;
};

export const MATCHES: Match[] = [
  {
    id: "m1",
    date: "2026-06-11",
    time: "20:00",
    stage: "Group Stage",
    group: "A",
    home: "Mexico",
    homeFlag: "🇲🇽",
    away: "Morocco",
    awayFlag: "🇲🇦",
    city: "Mexico City",
    stadium: "Estadio Azteca",
    status: "live",
    homeScore: 1,
    awayScore: 0,
  },
  {
    id: "m2",
    date: "2026-06-12",
    time: "18:00",
    stage: "Group Stage",
    group: "B",
    home: "Canada",
    homeFlag: "🇨🇦",
    away: "Belgium",
    awayFlag: "🇧🇪",
    city: "Toronto",
    stadium: "BMO Field",
    status: "upcoming",
  },
  {
    id: "m3",
    date: "2026-06-12",
    time: "21:00",
    stage: "Group Stage",
    group: "C",
    home: "USA",
    homeFlag: "🇺🇸",
    away: "England",
    awayFlag: "🏴󠁧󠁢󠁥󠁮󠁧󠁿",
    city: "Los Angeles",
    stadium: "SoFi Stadium",
    status: "upcoming",
  },
  {
    id: "m4",
    date: "2026-06-13",
    time: "15:00",
    stage: "Group Stage",
    group: "D",
    home: "Brazil",
    homeFlag: "🇧🇷",
    away: "Japan",
    awayFlag: "🇯🇵",
    city: "Miami",
    stadium: "Hard Rock Stadium",
    status: "upcoming",
  },
  {
    id: "m5",
    date: "2026-06-13",
    time: "20:00",
    stage: "Group Stage",
    group: "E",
    home: "France",
    homeFlag: "🇫🇷",
    away: "Senegal",
    awayFlag: "🇸🇳",
    city: "Dallas",
    stadium: "AT&T Stadium",
    status: "upcoming",
  },
  {
    id: "m6",
    date: "2026-06-14",
    time: "17:00",
    stage: "Group Stage",
    group: "F",
    home: "Argentina",
    homeFlag: "🇦🇷",
    away: "Croatia",
    awayFlag: "🇭🇷",
    city: "New York / New Jersey",
    stadium: "MetLife Stadium",
    status: "upcoming",
  },
  {
    id: "m7",
    date: "2026-06-10",
    time: "19:00",
    stage: "Group Stage",
    group: "A",
    home: "Mexico",
    homeFlag: "🇲🇽",
    away: "Ecuador",
    awayFlag: "🇪🇨",
    city: "Mexico City",
    stadium: "Estadio Azteca",
    status: "finished",
    homeScore: 2,
    awayScore: 1,
  },
  {
    id: "m8",
    date: "2026-06-10",
    time: "21:00",
    stage: "Group Stage",
    group: "B",
    home: "Spain",
    homeFlag: "🇪🇸",
    away: "Portugal",
    awayFlag: "🇵🇹",
    city: "Vancouver",
    stadium: "BC Place",
    status: "finished",
    homeScore: 3,
    awayScore: 2,
  },
  {
    id: "m9",
    date: "2026-06-15",
    time: "20:00",
    stage: "Group Stage",
    group: "G",
    home: "Germany",
    homeFlag: "🇩🇪",
    away: "Netherlands",
    awayFlag: "🇳🇱",
    city: "Houston",
    stadium: "NRG Stadium",
    status: "upcoming",
  },
  {
    id: "m10",
    date: "2026-06-16",
    time: "18:00",
    stage: "Group Stage",
    group: "H",
    home: "Italy",
    homeFlag: "🇮🇹",
    away: "Uruguay",
    awayFlag: "🇺🇾",
    city: "Atlanta",
    stadium: "Mercedes-Benz Stadium",
    status: "upcoming",
  },
];

function MatchCard({ m }: { m: Match }) {
  const live = m.status === "live";
  const finished = m.status === "finished";
  return (
    <Link to={`/fixtures/${m.id}`} className={`block panel rounded-lg p-5 transition group hover:border-primary ${live ? "border-primary" : ""}`}>
      <div className="flex items-center justify-between text-[11px] font-mono mb-4 uppercase tracking-wider">
        <span className="text-muted-foreground">
          {m.stage} {m.group && `· GROUP ${m.group}`}
        </span>
        {live ? (
          <span className="flex items-center gap-1.5 text-primary font-bold">
            <span className="h-1.5 w-1.5 rounded-full bg-primary animate-pulse-dot" /> LIVE
          </span>
        ) : finished ? (
          <span className="text-muted-foreground">FT</span>
        ) : (
        //   <span className="text-accent flex items-center gap-1"><Clock className="h-3 w-3" /> {m.time}</span>
          <span className="text-accent flex items-center gap-1">{m.time}</span>
        )}
      </div>
      <div className="flex items-center justify-between gap-3">
        <div className="flex-1 text-right">
          <div className="text-3xl mb-1">{m.homeFlag}</div>
          <div className="font-semibold text-sm">{m.home}</div>
        </div>
        <div className="px-4">
          {m.homeScore != null ? (
            <div className="text-3xl font-display tabular-nums">
              {m.homeScore}<span className="mx-2 text-muted-foreground">:</span>{m.awayScore}
            </div>
          ) : (
            <div className="text-2xl font-display text-muted-foreground">VS</div>
          )}
        </div>
        <div className="flex-1 text-left">
          <div className="text-3xl mb-1">{m.awayFlag}</div>
          <div className="font-semibold text-sm">{m.away}</div>
        </div>
      </div>
      <div className="mt-4 pt-3 border-t border-border flex items-center justify-between text-[11px] text-muted-foreground">
        {/* <span className="flex items-center gap-1.5"><MapPin className="h-3 w-3" /> {m.stadium}</span> */}
        <span className="flex items-center gap-1.5">{m.stadium}</span>
        <span className="text-primary opacity-0 group-hover:opacity-100 flex items-center gap-1 font-mono uppercase">
          {/* Details <ArrowRight className="h-3 w-3" /> */}
          Details
        </span>
      </div>
    </Link>
  );
}

export function Fixtures() {
  const [filter, setFilter] = useState<(typeof FILTERS)[number]>("All");

  const grouped = useMemo(() => {
    const filtered = MATCHES.filter((m) =>
      filter === "All" ? true : m.status === filter.toLowerCase(),
    );
    const byDate: Record<string, Match[]> = {};
    for (const m of filtered) (byDate[m.date] ||= []).push(m);
    return Object.entries(byDate).sort(([a], [b]) => a.localeCompare(b));
  }, [filter]);

  return (
    <div className="mx-auto max-w-7xl px-6 py-8">
      <div className="flex items-end justify-between flex-wrap gap-4 mb-6">
        <div>
          <div className="text-xs font-mono uppercase tracking-widest text-muted-foreground">Schedule</div>
          <h1 className="text-4xl md:text-5xl font-display tracking-wide mt-1">Match Fixtures</h1>
        </div>
        <div className="flex gap-1 panel rounded-full p-1">
          {FILTERS.map((f) => (
            <button
              key={f}
              onClick={() => setFilter(f)}
              className={`px-4 py-1.5 rounded-full text-xs font-bold uppercase tracking-wide transition ${
                filter === f ? "bg-primary text-primary-foreground" : "text-muted-foreground hover:text-foreground"
              }`}
            >
              {f}
            </button>
          ))}
        </div>
      </div>

      <div className="space-y-8">
        {grouped.map(([date, matches]) => (
          <div key={date} className="animate-float-up">
            <div className="flex items-center gap-3 mb-4">
              <div className="text-lg font-display tracking-wide">
                {new Date(date).toLocaleDateString("en-US", { weekday: "long", month: "short", day: "numeric" })}
              </div>
              <div className="flex-1 h-px bg-border" />
              <span className="text-[11px] font-mono text-muted-foreground">{matches.length} {matches.length === 1 ? "MATCH" : "MATCHES"}</span>
            </div>
            <div className="grid md:grid-cols-2 gap-4">
              {matches.map((m) => <MatchCard key={m.id} m={m} />)}
            </div>
          </div>
        ))}
        {grouped.length === 0 && (
          <div className="text-center py-20 text-muted-foreground">No matches in this view.</div>
        )}
      </div>
    </div>
  );
}
