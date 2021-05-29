import { Match } from "src/app/shared/models/match.model";

export interface Matchday {
    day: number;
    matches: Match[]
}