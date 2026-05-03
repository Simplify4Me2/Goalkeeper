export interface Team {
  id: number
  name: string
}

export async function fetchTeams(): Promise<Team[]> {
  const response = await fetch('/api/teams')

  if (!response.ok) {
    throw new Error(`Failed to fetch teams: ${response.status} ${response.statusText}`)
  }

  return response.json() as Promise<Team[]>
}
