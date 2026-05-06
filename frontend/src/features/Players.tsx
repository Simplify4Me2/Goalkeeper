import { useMemo, useState } from "react";

const POSITIONS = ["All", "GK", "DEF", "MID", "FWD"] as const;

export type Player = {
  id: string;
  name: string;
  team: string;
  flag: string;
  position: "GK" | "DEF" | "MID" | "FWD";
  number: number;
  goals: number;
  assists: number;
  passAccuracy: number;
  distanceKm: number;
  yellowCards: number;
  redCards: number;
  rating: number;
};

export const PLAYERS: Player[] = [
  { id: "p1", name: "Lionel Messi", team: "Argentina", flag: "🇦🇷", position: "FWD", number: 10, goals: 4, assists: 3, passAccuracy: 89, distanceKm: 32.4, yellowCards: 0, redCards: 0, rating: 9.4 },
  { id: "p2", name: "Kylian Mbappé", team: "France", flag: "🇫🇷", position: "FWD", number: 10, goals: 5, assists: 1, passAccuracy: 82, distanceKm: 28.7, yellowCards: 1, redCards: 0, rating: 9.2 },
  { id: "p3", name: "Vinicius Jr", team: "Brazil", flag: "🇧🇷", position: "FWD", number: 7, goals: 3, assists: 4, passAccuracy: 84, distanceKm: 30.1, yellowCards: 1, redCards: 0, rating: 8.9 },
  { id: "p4", name: "Jude Bellingham", team: "England", flag: "🏴󠁧󠁢󠁥󠁮󠁧󠁿", position: "MID", number: 22, goals: 2, assists: 5, passAccuracy: 91, distanceKm: 36.8, yellowCards: 0, redCards: 0, rating: 9.0 },
  { id: "p5", name: "Erling Haaland", team: "Norway", flag: "🇳🇴", position: "FWD", number: 9, goals: 6, assists: 0, passAccuracy: 76, distanceKm: 25.3, yellowCards: 0, redCards: 0, rating: 9.1 },
  { id: "p6", name: "Christian Pulisic", team: "USA", flag: "🇺🇸", position: "MID", number: 10, goals: 2, assists: 3, passAccuracy: 87, distanceKm: 33.5, yellowCards: 1, redCards: 0, rating: 8.5 },
  { id: "p7", name: "Alphonso Davies", team: "Canada", flag: "🇨🇦", position: "DEF", number: 19, goals: 1, assists: 2, passAccuracy: 88, distanceKm: 34.9, yellowCards: 1, redCards: 0, rating: 8.4 },
  { id: "p8", name: "Hirving Lozano", team: "Mexico", flag: "🇲🇽", position: "FWD", number: 22, goals: 2, assists: 1, passAccuracy: 80, distanceKm: 29.8, yellowCards: 0, redCards: 0, rating: 8.2 },
  { id: "p9", name: "Pedri", team: "Spain", flag: "🇪🇸", position: "MID", number: 8, goals: 1, assists: 4, passAccuracy: 93, distanceKm: 35.6, yellowCards: 0, redCards: 0, rating: 8.7 },
  { id: "p10", name: "Joshua Kimmich", team: "Germany", flag: "🇩🇪", position: "MID", number: 6, goals: 0, assists: 3, passAccuracy: 92, distanceKm: 37.2, yellowCards: 2, redCards: 0, rating: 8.3 },
  { id: "p11", name: "Thibaut Courtois", team: "Belgium", flag: "🇧🇪", position: "GK", number: 1, goals: 0, assists: 0, passAccuracy: 78, distanceKm: 12.5, yellowCards: 0, redCards: 0, rating: 8.6 },
  { id: "p12", name: "Virgil van Dijk", team: "Netherlands", flag: "🇳🇱", position: "DEF", number: 4, goals: 1, assists: 0, passAccuracy: 90, distanceKm: 27.3, yellowCards: 1, redCards: 0, rating: 8.5 },
];

function Bar({ value, max, color }: { value: number; max: number; color: string }) {
  return (
    <div className="h-1.5 bg-secondary rounded-full overflow-hidden">
      <div className="h-full rounded-full transition-all" style={{ width: `${(value / max) * 100}%`, background: color }} />
    </div>
  );
}

function PlayerCard({ p }: { p: Player }) {
  return (
    <div className="panel rounded-lg p-5 hover:border-primary transition group">
      <div className="flex items-start justify-between">
        <div>
          <div className="flex items-center gap-2">
            <span className="text-2xl">{p.flag}</span>
            <span className="font-mono text-xs text-muted-foreground">#{p.number}</span>
            <span className="text-[10px] px-1.5 py-0.5 rounded bg-accent/20 text-accent font-mono">{p.position}</span>
          </div>
          <h3 className="mt-2 text-lg font-bold">{p.name}</h3>
          <div className="text-xs text-muted-foreground">{p.team}</div>
        </div>
        <div className="text-right">
          <div className="text-[10px] uppercase tracking-wider text-muted-foreground">Rating</div>
          <div className="text-2xl font-display text-primary tabular-nums">{p.rating.toFixed(1)}</div>
        </div>
      </div>
      <div className="mt-4 grid grid-cols-2 gap-3 text-xs">
        {/* <div className="flex items-center gap-2"><Target className="h-3 w-3 text-primary" /> <span className="font-mono tabular-nums">{p.goals}G {p.assists}A</span></div> */}
        <div className="flex items-center gap-2"> <span className="font-mono tabular-nums">{p.goals}G {p.assists}A</span></div>
        {/* <div className="flex items-center gap-2"><Activity className="h-3 w-3 text-accent" /> <span className="font-mono tabular-nums">{p.distanceKm}km</span></div> */}
        <div className="flex items-center gap-2"> <span className="font-mono tabular-nums">{p.distanceKm}km</span></div>
      </div>
      <div className="mt-4 space-y-2">
        <div>
          <div className="flex justify-between text-[10px] font-mono text-muted-foreground mb-1">
            <span>PASS ACC</span><span>{p.passAccuracy}%</span>
          </div>
          <Bar value={p.passAccuracy} max={100} color="oklch(0.45 0.20 255)" />
        </div>
        <div>
          <div className="flex justify-between text-[10px] font-mono text-muted-foreground mb-1">
            <span>RATING</span><span>{p.rating}/10</span>
          </div>
          <Bar value={p.rating} max={10} color="oklch(0.55 0.22 25)" />
        </div>
      </div>
      <div className="mt-3 pt-3 border-t border-border/30 flex items-center gap-3 text-xs text-muted-foreground">
        {/* <span className="flex items-center gap-1"><Square className="h-2.5 w-2.5 fill-yellow-400 text-yellow-400" />{p.yellowCards}</span> */}
        <span className="flex items-center gap-1">{p.yellowCards}</span>
        {/* <span className="flex items-center gap-1"><Square className="h-2.5 w-2.5 fill-red-500 text-red-500" />{p.redCards}</span> */}
        <span className="flex items-center gap-1">{p.redCards}</span>
      </div>
    </div>
  );
}

export function Players() {
  const [q, setQ] = useState("");
  const [pos, setPos] = useState<(typeof POSITIONS)[number]>("All");
  const [sort, setSort] = useState<"rating" | "goals" | "assists">("rating");

  const filtered = useMemo(() => {
    return PLAYERS.filter((p) => pos === "All" || p.position === pos)
      .filter(
        (p) =>
          q === "" ||
          p.name.toLowerCase().includes(q.toLowerCase()) ||
          p.team.toLowerCase().includes(q.toLowerCase()),
      )
      .sort((a, b) => b[sort] - a[sort]);
  }, [q, pos, sort]);

  return (
    <div className="mx-auto max-w-7xl px-6 py-8">
      <div className="mb-6">
        <div className="text-xs font-mono uppercase tracking-widest text-muted-foreground">Performance</div>
        <h1 className="text-4xl md:text-5xl font-display tracking-wide mt-1">Player Statistics</h1>
      </div>

      <div className="panel rounded-lg p-4 mb-6 flex flex-wrap gap-3 items-center">
        <div className="relative flex-1 min-w-[220px]">
          {/* <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-muted-foreground" /> */}
          <input
            value={q}
            onChange={(e) => setQ(e.target.value)}
            placeholder="Search player or team..."
            className="w-full bg-input border border-border rounded-md pl-9 pr-3 py-2 text-sm focus:outline-none focus:border-primary"
          />
        </div>
        <div className="flex gap-1 panel rounded-full p-1">
          {POSITIONS.map((p) => (
            <button key={p} onClick={() => setPos(p)} className={`px-3 py-1 rounded-full text-xs font-bold uppercase tracking-wide transition ${pos === p ? "bg-accent text-accent-foreground" : "text-muted-foreground hover:text-foreground"}`}>{p}</button>
          ))}
        </div>
        <select value={sort} onChange={(e) => setSort(e.target.value as never)} className="bg-input border border-border rounded-md px-3 py-2 text-sm">
          <option value="rating">Sort: Rating</option>
          <option value="goals">Sort: Goals</option>
          <option value="assists">Sort: Assists</option>
        </select>
      </div>

      <div className="grid sm:grid-cols-2 lg:grid-cols-3 gap-4">
        {filtered.map((p) => <PlayerCard key={p.id} p={p} />)}
      </div>
      {filtered.length === 0 && <div className="text-center py-20 text-muted-foreground">No players match.</div>}
    </div>
  );
}
