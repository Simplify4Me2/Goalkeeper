import { useTeams } from '../hooks/useTeams'
import '../styles/Teams.css'

export function Teams() {
  const { teams, loading, error } = useTeams()

  return (
    <section className="teams-section" aria-labelledby="teams-heading">
      <div className="card">
        <h2 id="teams-heading" className="section-title">World Cup 2026 Teams</h2>

        {error && (
          <div className="error-message" role="alert" aria-live="polite">
            <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" aria-hidden="true">
              <circle cx="12" cy="12" r="10"/>
              <line x1="12" y1="8" x2="12" y2="12"/>
              <line x1="12" y1="16" x2="12.01" y2="16"/>
            </svg>
            <span>{error}</span>
          </div>
        )}

        {loading && teams.length === 0 && (
          <div className="loading-skeleton" role="status" aria-live="polite" aria-label="Loading teams">
            {[...Array(12)].map((_, i) => (
              <div key={i} className="skeleton-card" aria-hidden="true" />
            ))}
            <span className="visually-hidden">Loading teams...</span>
          </div>
        )}

        {teams.length > 0 && (
          <div className="teams-grid">
            {teams.map((team) => (
              <div key={team.id} className="team-card">
                <h3 className="team-name">{team.name}</h3>
              </div>
            ))}
          </div>
        )}

        {!loading && teams.length === 0 && !error && (
          <p className="empty-message">No teams available.</p>
        )}
      </div>
    </section>
  )
}
