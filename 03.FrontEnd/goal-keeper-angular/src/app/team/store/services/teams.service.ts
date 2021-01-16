import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

import { Player, Team } from '../../models';
import { RequestResult } from '../../../shared/request-result';

@Injectable({
    providedIn: 'root'
})
export class TeamsService {

    constructor(private http: HttpClient) {}

    teams = {
        5: {
            id: 5,
            name: 'Club Brugge',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        98: {
            id: 98,
            name: 'KAA Gent',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        65: {
            id: 65,
            name: 'Charleroi',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        10: {
            id: 10,
            name: 'Antwerp',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        23: {
            id: 23,
            name: 'Standard',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        67: {
            id: 67,
            name: 'KV Mechelen',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        29: {
            id: 29,
            name: 'KRC Genk',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        58: {
            id: 58,
            name: 'Anderlecht',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        11: {
            id: 11,
            name: 'Zulte Waregem',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        39: {
            id: 39,
            name: 'Excel Moeskroen',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        31: {
            id: 31,
            name: 'KV Kortrijk',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        19: {
            id: 19,
            name: 'STVV',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        44: {
            id: 44,
            name: 'KAS Eupen',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        21: {
            id: 21,
            name: 'Cercle Brugge',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        12: {
            id: 12,
            name: 'KV Oostende',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        },
        8: {
            id: 8,
            name: 'Waasland-Beveren',
            players: [
                { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
                { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
                { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
                { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
                { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
                { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
            ]
        }
    };

    players: Player[] = [
        { id: 1, firstName: 'Jelle', lastName: 'Vossen', shirtNumber: 16, position: 'ATT' },
        { id: 2, firstName: 'Hans', lastName: 'Vanaken', shirtNumber: 7, position: 'MID' },
        { id: 3, firstName: 'Jérémy', lastName: 'Doku', shirtNumber: 23, position: 'ATT' },
        { id: 4, firstName: 'Mats', lastName: 'Rits', shirtNumber: 36, position: 'ATT' },
        { id: 5, firstName: 'Olivier', lastName: 'Deschacht', shirtNumber: 3, position: 'DEF' },
        { id: 6, firstName: 'Lukas', lastName: 'Nmecha', shirtNumber: 9, position: 'ATT' },
    ]

    deprecatedGetTeam(id: number): Observable<Team> {
        return of(this.teams[id]);
    }

    getTeam(id: number): Observable<RequestResult<Team>> {
        return this.http.get<RequestResult<Team>>(`https://localhost:5001/api/team/${id}`);
    }

    getPlayers(teamId: number): Observable<Player[]> {
        console.log('getPlayers teamId: ', teamId);
        return of(this.players);
    }
}