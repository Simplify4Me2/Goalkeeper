import { useState, useEffect, useCallback } from 'react'
import { fetchTeams, type Team } from '../api/teams'

interface UseTeamsResult {
  teams: Team[]
  loading: boolean
  error: string | null
  refetch: () => void
}

export function useTeams(): UseTeamsResult {
  const [teams, setTeams] = useState<Team[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)

  const load = useCallback(async () => {
    setLoading(true)
    setError(null)

    try {
      const data = await fetchTeams()
      setTeams(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to fetch teams')
    } finally {
      setLoading(false)
    }
  }, [])

  useEffect(() => {
    void load()
  }, [load])

  return { teams, loading, error, refetch: load }
}
