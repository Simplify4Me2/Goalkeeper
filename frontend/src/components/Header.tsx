const NAV = [
  { to: "/", label: "Dashboard" },
  { to: "/fixtures", label: "Fixtures" },
  { to: "/teams", label: "Teams" },
  { to: "/players", label: "Players" },
] as const;

export default function Header() {
//   const loc = useLocation();
  return (
    <header className="sticky top-0 z-50 bg-background/85 backdrop-blur border-b border-border">
        <h1>Hey header</h1>
      {/* <div className="mx-auto max-w-7xl px-6 h-16 flex items-center justify-between">
        <Link to="/" className="flex items-center gap-2.5">
          <div className="h-9 w-9 rounded-md bg-primary text-primary-foreground grid place-items-center shadow-sm">
            <Trophy className="h-5 w-5" />
          </div>
          <div className="leading-tight">
            <div className="text-[10px] uppercase tracking-[0.25em] text-muted-foreground font-mono">FIFA · 2026</div>
            <div className="text-base font-bold tracking-wide">WC26 ANALYTICS</div>
          </div>
        </Link>
        <nav className="hidden md:flex items-center gap-1">
          {NAV.map((n) => {
            const active = n.to === "/" ? loc.pathname === "/" : loc.pathname.startsWith(n.to);
            return (
              <Link
                key={n.to}
                to={n.to}
                className={`relative px-4 py-2 text-sm font-semibold uppercase tracking-wide rounded-md transition-colors ${
                  active ? "text-primary" : "text-muted-foreground hover:text-foreground"
                }`}
              >
                {n.label}
                {active && (
                  <span className="absolute inset-x-3 -bottom-px h-0.5 bg-primary rounded" />
                )}
              </Link>
            );
          })}
        </nav>
        <div className="hidden sm:flex items-center gap-2 chip">
          <span className="h-2 w-2 rounded-full bg-primary animate-pulse-dot" />
          <span>LIVE · 2026</span>
        </div>
      </div> */}
    </header>
  );
}