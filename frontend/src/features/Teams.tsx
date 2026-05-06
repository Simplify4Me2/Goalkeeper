import { useMemo, useState } from "react";
import { Link } from "react-router";
import { Radar, RadarChart, PolarGrid, PolarAngleAxis, ResponsiveContainer, PolarRadiusAxis } from "recharts";

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

function StandingsTable({ rows }: { rows: TeamStanding[] }) {
  const sorted = [...rows].sort((a, b) => b.points - a.points || (b.gf - b.ga) - (a.gf - a.ga));
  return (
    <div className="panel rounded-lg overflow-hidden">
      <div className="px-4 py-2.5 flex items-center justify-between bg-secondary border-b border-border">
        <div className="font-display text-base tracking-wide">Group {rows[0].group}</div>
        <div className="text-[10px] font-mono text-muted-foreground">{rows.length} TEAMS</div>
      </div>
      <table className="w-full text-sm">
        <thead className="text-[10px] font-mono uppercase text-muted-foreground bg-muted/40">
          <tr>
            <th className="text-left px-4 py-2">Team</th>
            <th className="text-center px-2 py-2">P</th>
            <th className="text-center px-2 py-2">W</th>
            <th className="text-center px-2 py-2">D</th>
            <th className="text-center px-2 py-2">L</th>
            <th className="text-center px-2 py-2">GD</th>
            <th className="text-center px-3 py-2 text-primary">PTS</th>
          </tr>
        </thead>
        <tbody>
          {sorted.map((t, i) => (
            <tr key={t.team} className="border-b border-border/60 last:border-0 hover:bg-secondary/60">
              <td className="px-4 py-2.5">
                <Link to={`/teams/${teamSlug(t.team)}`} className="flex items-center gap-2 hover:text-primary">
                  <span className={`text-[10px] w-4 font-mono ${i < 2 ? "text-primary" : "text-muted-foreground"}`}>{i + 1}</span>
                  <span className="text-xl">{t.flag}</span>
                  <span className="font-medium">{t.team}</span>
                </Link>
              </td>
              <td className="text-center tabular-nums">{t.played}</td>
              <td className="text-center tabular-nums">{t.won}</td>
              <td className="text-center tabular-nums">{t.drawn}</td>
              <td className="text-center tabular-nums">{t.lost}</td>
              <td className="text-center tabular-nums">{t.gf - t.ga > 0 ? "+" : ""}{t.gf - t.ga}</td>
              <td className="text-center px-3 font-bold text-primary tabular-nums">{t.points}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export function Teams() {
  const groups = useMemo(() => {
    const map: Record<string, TeamStanding[]> = {};
    for (const s of STANDINGS) (map[s.group] ||= []).push(s);
    return Object.entries(map);
  }, []);

  const allTeams = STANDINGS.map((s) => s.team);
  const [a, setA] = useState("Brazil");
  const [b, setB] = useState("France");

  const teamA = STANDINGS.find((s) => s.team === a)!;
  const teamB = STANDINGS.find((s) => s.team === b)!;
  const radarData = [
    { metric: "Attack", a: teamA.attack, b: teamB.attack },
    { metric: "Defense", a: teamA.defense, b: teamB.defense },
    { metric: "Possession", a: teamA.possession, b: teamB.possession },
    { metric: "Passing", a: teamA.passing, b: teamB.passing },
    { metric: "Pressing", a: teamA.pressing, b: teamB.pressing },
  ];

  return (
    <div className="mx-auto max-w-7xl px-6 py-8">
      <div className="mb-6">
        <div className="text-xs font-mono uppercase tracking-widest text-muted-foreground">Tactical</div>
        <h1 className="text-4xl md:text-5xl font-display tracking-wide mt-1">Teams & Standings</h1>
      </div>

      <section className="panel rounded-xl p-6 mb-8">
        <div className="flex flex-wrap items-center justify-between gap-4 mb-4">
          <div>
            <div className="text-xs font-mono uppercase text-muted-foreground">Head-to-Head Radar</div>
            <h2 className="text-xl font-display tracking-wide mt-1">Compare Tactical DNA</h2>
          </div>
          <div className="flex gap-2 items-center">
            <select value={a} onChange={(e) => setA(e.target.value)} className="bg-input border border-primary/40 rounded-md px-3 py-2 text-sm font-medium text-primary">
              {allTeams.map((t) => <option key={t}>{t}</option>)}
            </select>
            <span className="text-muted-foreground text-sm">vs</span>
            <select value={b} onChange={(e) => setB(e.target.value)} className="bg-input border border-accent/40 rounded-md px-3 py-2 text-sm font-medium text-accent">
              {allTeams.map((t) => <option key={t}>{t}</option>)}
            </select>
          </div>
        </div>
        <div className="h-[340px]">
          <ResponsiveContainer>
            <RadarChart data={radarData}>
              <PolarGrid stroke="oklch(0.85 0.02 130)" />
              <PolarAngleAxis dataKey="metric" tick={{ fill: "oklch(0.45 0.03 240)", fontSize: 12 }} />
              <PolarRadiusAxis angle={90} domain={[0, 100]} tick={false} axisLine={false} />
              <Radar name={a} dataKey="a" stroke="oklch(0.55 0.22 25)" fill="oklch(0.55 0.22 25)" fillOpacity={0.3} strokeWidth={2} />
              <Radar name={b} dataKey="b" stroke="oklch(0.45 0.20 255)" fill="oklch(0.45 0.20 255)" fillOpacity={0.25} strokeWidth={2} />
            </RadarChart>
          </ResponsiveContainer>
        </div>
        <div className="flex gap-6 justify-center text-sm">
          <span className="flex items-center gap-2"><span className="h-3 w-3 rounded-full bg-primary" /> {a}</span>
          <span className="flex items-center gap-2"><span className="h-3 w-3 rounded-full bg-accent" /> {b}</span>
        </div>
      </section>

      <h2 className="text-2xl font-display tracking-wide mb-4">Group Standings</h2>
      <div className="grid md:grid-cols-2 gap-5">
        {groups.map(([g, rows]) => <StandingsTable key={g} rows={rows} />)}
      </div>
    </div>
  );
}
