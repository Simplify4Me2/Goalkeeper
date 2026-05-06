import { useMemo } from "react";
import { Link } from "react-router";

export type HostCity = {
  name: string;
  country: "USA" | "Canada" | "Mexico";
  stadium: string;
  capacity: number;
  matches: number;
  lat: number;
  lng: number;
};

export const HOST_CITIES: HostCity[] = [
  { name: "New York / New Jersey", country: "USA", stadium: "MetLife Stadium", capacity: 82500, matches: 8, lat: 40.8135, lng: -74.0745 },
  { name: "Los Angeles", country: "USA", stadium: "SoFi Stadium", capacity: 70240, matches: 8, lat: 33.9535, lng: -118.3392 },
  { name: "Dallas", country: "USA", stadium: "AT&T Stadium", capacity: 80000, matches: 9, lat: 32.7473, lng: -97.0945 },
  { name: "Atlanta", country: "USA", stadium: "Mercedes-Benz Stadium", capacity: 71000, matches: 8, lat: 33.7553, lng: -84.4006 },
  { name: "Miami", country: "USA", stadium: "Hard Rock Stadium", capacity: 65326, matches: 7, lat: 25.9580, lng: -80.2389 },
  { name: "Seattle", country: "USA", stadium: "Lumen Field", capacity: 68740, matches: 6, lat: 47.5952, lng: -122.3316 },
  { name: "San Francisco", country: "USA", stadium: "Levi's Stadium", capacity: 68500, matches: 6, lat: 37.4030, lng: -121.9700 },
  { name: "Boston", country: "USA", stadium: "Gillette Stadium", capacity: 65878, matches: 7, lat: 42.0909, lng: -71.2643 },
  { name: "Philadelphia", country: "USA", stadium: "Lincoln Financial Field", capacity: 69596, matches: 6, lat: 39.9008, lng: -75.1675 },
  { name: "Houston", country: "USA", stadium: "NRG Stadium", capacity: 72220, matches: 7, lat: 29.6847, lng: -95.4107 },
  { name: "Kansas City", country: "USA", stadium: "Arrowhead Stadium", capacity: 76416, matches: 6, lat: 39.0489, lng: -94.4839 },
  { name: "Toronto", country: "Canada", stadium: "BMO Field", capacity: 45500, matches: 6, lat: 43.6332, lng: -79.4185 },
  { name: "Vancouver", country: "Canada", stadium: "BC Place", capacity: 54500, matches: 7, lat: 49.2767, lng: -123.1118 },
  { name: "Mexico City", country: "Mexico", stadium: "Estadio Azteca", capacity: 87523, matches: 5, lat: 19.3029, lng: -99.1505 },
  { name: "Guadalajara", country: "Mexico", stadium: "Estadio Akron", capacity: 49850, matches: 4, lat: 20.6817, lng: -103.4625 },
  { name: "Monterrey", country: "Mexico", stadium: "Estadio BBVA", capacity: 53500, matches: 4, lat: 25.6692, lng: -100.2444 },
];

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
  { id: "m1", date: "2026-06-11", time: "20:00", stage: "Group Stage", group: "A", home: "Mexico", homeFlag: "🇲🇽", away: "Morocco", awayFlag: "🇲🇦", city: "Mexico City", stadium: "Estadio Azteca", status: "live", homeScore: 1, awayScore: 0 },
  { id: "m2", date: "2026-06-12", time: "18:00", stage: "Group Stage", group: "B", home: "Canada", homeFlag: "🇨🇦", away: "Belgium", awayFlag: "🇧🇪", city: "Toronto", stadium: "BMO Field", status: "upcoming" },
  { id: "m3", date: "2026-06-12", time: "21:00", stage: "Group Stage", group: "C", home: "USA", homeFlag: "🇺🇸", away: "England", awayFlag: "🏴󠁧󠁢󠁥󠁮󠁧󠁿", city: "Los Angeles", stadium: "SoFi Stadium", status: "upcoming" },
  { id: "m4", date: "2026-06-13", time: "15:00", stage: "Group Stage", group: "D", home: "Brazil", homeFlag: "🇧🇷", away: "Japan", awayFlag: "🇯🇵", city: "Miami", stadium: "Hard Rock Stadium", status: "upcoming" },
  { id: "m5", date: "2026-06-13", time: "20:00", stage: "Group Stage", group: "E", home: "France", homeFlag: "🇫🇷", away: "Senegal", awayFlag: "🇸🇳", city: "Dallas", stadium: "AT&T Stadium", status: "upcoming" },
  { id: "m6", date: "2026-06-14", time: "17:00", stage: "Group Stage", group: "F", home: "Argentina", homeFlag: "🇦🇷", away: "Croatia", awayFlag: "🇭🇷", city: "New York / New Jersey", stadium: "MetLife Stadium", status: "upcoming" },
  { id: "m7", date: "2026-06-10", time: "19:00", stage: "Group Stage", group: "A", home: "Mexico", homeFlag: "🇲🇽", away: "Ecuador", awayFlag: "🇪🇨", city: "Mexico City", stadium: "Estadio Azteca", status: "finished", homeScore: 2, awayScore: 1 },
  { id: "m8", date: "2026-06-10", time: "21:00", stage: "Group Stage", group: "B", home: "Spain", homeFlag: "🇪🇸", away: "Portugal", awayFlag: "🇵🇹", city: "Vancouver", stadium: "BC Place", status: "finished", homeScore: 3, awayScore: 2 },
  { id: "m9", date: "2026-06-15", time: "20:00", stage: "Group Stage", group: "G", home: "Germany", homeFlag: "🇩🇪", away: "Netherlands", awayFlag: "🇳🇱", city: "Houston", stadium: "NRG Stadium", status: "upcoming" },
  { id: "m10", date: "2026-06-16", time: "18:00", stage: "Group Stage", group: "H", home: "Italy", homeFlag: "🇮🇹", away: "Uruguay", awayFlag: "🇺🇾", city: "Atlanta", stadium: "Mercedes-Benz Stadium", status: "upcoming" },
];

export type TeamStanding = {
  group: string;
  team: string;
  flag: string;
  played: number;
  won: number;
  drawn: number;
  lost: number;
  gf: number;
  ga: number;
  points: number;
  possession: number;
  defense: number;
  attack: number;
  passing: number;
  pressing: number;
};

export const STANDINGS: TeamStanding[] = [
  { group: "A", team: "Mexico", flag: "🇲🇽", played: 2, won: 2, drawn: 0, lost: 0, gf: 5, ga: 1, points: 6, possession: 58, defense: 82, attack: 78, passing: 85, pressing: 75 },
  { group: "A", team: "Morocco", flag: "🇲🇦", played: 2, won: 1, drawn: 0, lost: 1, gf: 3, ga: 2, points: 3, possession: 49, defense: 80, attack: 72, passing: 78, pressing: 82 },
  { group: "A", team: "Ecuador", flag: "🇪🇨", played: 2, won: 1, drawn: 0, lost: 1, gf: 2, ga: 3, points: 3, possession: 47, defense: 75, attack: 68, passing: 74, pressing: 78 },
  { group: "A", team: "Saudi Arabia", flag: "🇸🇦", played: 2, won: 0, drawn: 0, lost: 2, gf: 1, ga: 5, points: 0, possession: 42, defense: 68, attack: 62, passing: 70, pressing: 70 },
  { group: "B", team: "Spain", flag: "🇪🇸", played: 2, won: 2, drawn: 0, lost: 0, gf: 6, ga: 2, points: 6, possession: 65, defense: 80, attack: 88, passing: 92, pressing: 80 },
  { group: "B", team: "Belgium", flag: "🇧🇪", played: 2, won: 1, drawn: 1, lost: 0, gf: 4, ga: 2, points: 4, possession: 56, defense: 82, attack: 80, passing: 84, pressing: 76 },
  { group: "B", team: "Canada", flag: "🇨🇦", played: 2, won: 0, drawn: 1, lost: 1, gf: 2, ga: 4, points: 1, possession: 48, defense: 74, attack: 72, passing: 76, pressing: 80 },
  { group: "B", team: "Portugal", flag: "🇵🇹", played: 2, won: 0, drawn: 0, lost: 2, gf: 2, ga: 6, points: 0, possession: 54, defense: 72, attack: 84, passing: 86, pressing: 74 },
  { group: "C", team: "England", flag: "🏴󠁧󠁢󠁥󠁮󠁧󠁿", played: 2, won: 2, drawn: 0, lost: 0, gf: 5, ga: 1, points: 6, possession: 60, defense: 85, attack: 86, passing: 88, pressing: 82 },
  { group: "C", team: "USA", flag: "🇺🇸", played: 2, won: 1, drawn: 1, lost: 0, gf: 3, ga: 2, points: 4, possession: 52, defense: 78, attack: 76, passing: 80, pressing: 84 },
  { group: "C", team: "Senegal", flag: "🇸🇳", played: 2, won: 0, drawn: 1, lost: 1, gf: 1, ga: 2, points: 1, possession: 46, defense: 76, attack: 70, passing: 74, pressing: 80 },
  { group: "C", team: "Iran", flag: "🇮🇷", played: 2, won: 0, drawn: 0, lost: 2, gf: 0, ga: 4, points: 0, possession: 40, defense: 70, attack: 64, passing: 68, pressing: 72 },
  { group: "D", team: "Brazil", flag: "🇧🇷", played: 2, won: 2, drawn: 0, lost: 0, gf: 7, ga: 1, points: 6, possession: 62, defense: 84, attack: 92, passing: 90, pressing: 80 },
  { group: "D", team: "France", flag: "🇫🇷", played: 2, won: 2, drawn: 0, lost: 0, gf: 6, ga: 2, points: 6, possession: 58, defense: 86, attack: 90, passing: 88, pressing: 82 },
  { group: "D", team: "Japan", flag: "🇯🇵", played: 2, won: 1, drawn: 0, lost: 1, gf: 3, ga: 3, points: 3, possession: 54, defense: 78, attack: 76, passing: 84, pressing: 86 },
  { group: "D", team: "Argentina", flag: "🇦🇷", played: 2, won: 1, drawn: 1, lost: 0, gf: 5, ga: 2, points: 4, possession: 60, defense: 82, attack: 90, passing: 88, pressing: 78 },
];

export function teamSlug(team: string): string {
  return team.toLowerCase().replace(/[^a-z0-9]+/g, "-").replace(/^-|-$/g, "");
}

function StatCard({ label, value, hint }: { label: string; value: string; hint?: string }) {
  return (
    <div className="panel rounded-lg p-4">
      <div className="text-[10px] font-mono uppercase tracking-widest text-muted-foreground">{label}</div>
      <div className="mt-1 text-3xl font-display tracking-wide">{value}</div>
      {hint && <div className="text-[11px] text-muted-foreground mt-0.5">{hint}</div>}
    </div>
  );
}

function GroupTable({ rows }: { rows: TeamStanding[] }) {
  const sorted = [...rows].sort((a, b) => b.points - a.points || (b.gf - b.ga) - (a.gf - a.ga));
  return (
    <div className="panel rounded-lg overflow-hidden">
      <div className="px-3 py-2 flex items-center justify-between bg-secondary border-b border-border">
        <div className="font-display tracking-wide text-sm">Group {rows[0].group}</div>
        <span className="text-[10px] font-mono text-muted-foreground">PLD · PTS</span>
      </div>
      <table className="w-full text-sm">
        <tbody>
          {sorted.map((t, i) => (
            <tr key={t.team} className="border-b border-border/60 last:border-0">
              <td className="pl-3 pr-1 py-2 w-5 text-[11px] font-mono text-muted-foreground">{i + 1}</td>
              <td className="py-2">
                <Link to={`/teams/${teamSlug(t.team)}`}  className="flex items-center gap-2 hover:text-primary transition">
                  <span className="text-base">{t.flag}</span>
                  <span className={`font-medium ${i < 2 ? "" : "text-muted-foreground"}`}>{t.team}</span>
                </Link>
              </td>
              <td className="text-center text-xs tabular-nums text-muted-foreground w-8">{t.played}</td>
              <td className="text-center font-bold text-primary tabular-nums w-10 pr-3">{t.points}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

function MatchRow({ m }: { m: Match }) {
  const live = m.status === "live";
  return (
    <Link to={`/fixtures/${m.id}`} className="block panel rounded-lg p-3 hover:border-primary transition group">
      <div className="flex items-center justify-between text-[10px] font-mono mb-2 uppercase tracking-wider">
        <span className="text-muted-foreground">{new Date(m.date).toLocaleDateString("en-US", { month: "short", day: "numeric" })} · {m.time}</span>
        {live ? (
          <span className="flex items-center gap-1 text-primary font-bold">
            <span className="h-1.5 w-1.5 rounded-full bg-primary animate-pulse-dot" /> LIVE
          </span>
        ) : (
          <span className="text-muted-foreground">{m.group ? `GROUP ${m.group}` : m.stage}</span>
        )}
      </div>
      <div className="flex items-center gap-3">
        <div className="flex-1 flex items-center gap-2 min-w-0">
          <span className="text-xl shrink-0">{m.homeFlag}</span>
          <span className="font-semibold truncate">{m.home}</span>
        </div>
        <div className="px-2 font-mono font-bold tabular-nums text-lg">
          {live || m.status === "finished" ? `${m.homeScore} - ${m.awayScore}` : "vs"}
        </div>
        <div className="flex-1 flex items-center gap-2 justify-end min-w-0">
          <span className="font-semibold truncate text-right">{m.away}</span>
          <span className="text-xl shrink-0">{m.awayFlag}</span>
        </div>
      </div>
      <div className="mt-2 pt-2 border-t border-border/60 flex items-center justify-between text-[11px] text-muted-foreground">
        {/* <span className="flex items-center gap-1"><MapPin className="h-3 w-3" />{m.stadium}</span> */}
        <span className="flex items-center gap-1">{m.stadium}</span>
        <span className="opacity-0 group-hover:opacity-100 transition text-primary flex items-center gap-1">
          {/* Predict odds <ArrowRight className="h-3 w-3" /> */}
          Predict odds
        </span>
      </div>
    </Link>
  );
}

export function Dashboard() {
    const groups = useMemo(() => {
    const map: Record<string, TeamStanding[]> = {};
    for (const s of STANDINGS) (map[s.group] ||= []).push(s);
    return Object.entries(map);
  }, []);

  const totalCapacity = HOST_CITIES.reduce((s, c) => s + c.capacity, 0);
  const live = MATCHES.filter((m) => m.status === "live");
  const upcoming = MATCHES.filter((m) => m.status === "upcoming")
    .sort((a, b) => (a.date + a.time).localeCompare(b.date + b.time))
    .slice(0, 6);

    return (
    <div className="mx-auto max-w-7xl px-6 py-8">
      {/* Hero strip */}
      <section className="rounded-xl overflow-hidden mb-8 panel-strong">
        <div className="scoreboard p-6 md:p-8 flex flex-col md:flex-row md:items-center md:justify-between gap-6">
          <div>
            <div className="inline-flex items-center gap-2 chip bg-transparent border-white/20 text-white/80">
              {/* <Trophy className="h-3 w-3" /> JUNE 11 — JULY 19, 2026 */}
            </div>
            <h1 className="mt-3 text-4xl md:text-6xl font-display tracking-wide leading-none">
              Tournament <span className="text-trophy">Dashboard</span>
            </h1>
            <p className="mt-2 text-sm md:text-base text-white/70 max-w-xl font-body">
              Live overview of all 8 groups, upcoming kickoffs and access to AI-powered match odds.
            </p>
          </div>
          <div className="grid grid-cols-2 gap-3 md:w-[360px]">
            <div className="bg-white/10 rounded-md px-3 py-2 border border-white/15">
              <div className="text-[10px] font-mono uppercase opacity-70">Live</div>
              <div className="text-2xl font-display">{live.length}</div>
            </div>
            <div className="bg-white/10 rounded-md px-3 py-2 border border-white/15">
              <div className="text-[10px] font-mono uppercase opacity-70">Matches</div>
              <div className="text-2xl font-display">104</div>
            </div>
            <div className="bg-white/10 rounded-md px-3 py-2 border border-white/15">
              <div className="text-[10px] font-mono uppercase opacity-70">Host Cities</div>
              <div className="text-2xl font-display">16</div>
            </div>
            <div className="bg-white/10 rounded-md px-3 py-2 border border-white/15">
              <div className="text-[10px] font-mono uppercase opacity-70">Capacity</div>
              <div className="text-2xl font-display">{(totalCapacity / 1000).toFixed(0)}K</div>
            </div>
          </div>
        </div>
      </section>

      <div className="grid lg:grid-cols-3 gap-6">
        {/* Groups */}
        <section className="lg:col-span-2 animate-float-up">
          <div className="flex items-end justify-between mb-3">
            <h2 className="text-2xl font-display tracking-wide">Group Stage</h2>
            <Link to="/teams" className="text-xs font-mono uppercase text-primary hover:underline">All Teams →</Link>
          </div>
          <div className="grid sm:grid-cols-2 gap-4">
            {groups.map(([g, rows]) => <GroupTable key={g} rows={rows} />)}
          </div>
        </section>

        {/* Matches column */}
        <aside className="space-y-6">
          {live.length > 0 && (
            <section className="animate-float-up">
              <h2 className="text-2xl font-display tracking-wide mb-3 flex items-center gap-2">
                <span className="h-2 w-2 rounded-full bg-primary animate-pulse-dot" /> Live
              </h2>
              <div className="space-y-3">{live.map((m) => <MatchRow key={m.id} m={m} />)}</div>
            </section>
          )}
          <section className="animate-float-up">
            <div className="flex items-end justify-between mb-3">
              <h2 className="text-2xl font-display tracking-wide flex items-center gap-2">
                {/* <Calendar className="h-5 w-5 text-accent" /> Upcoming */}
                Upcoming
              </h2>
              <Link to="/fixtures" className="text-xs font-mono uppercase text-primary hover:underline">All →</Link>
            </div>
            <div className="space-y-3">{upcoming.map((m) => <MatchRow key={m.id} m={m} />)}</div>
          </section>
          <StatCard label="Tournament Window" value="39 Days" hint="11 Jun — 19 Jul 2026" />
        </aside>
      </div>
    </div>
  );
}