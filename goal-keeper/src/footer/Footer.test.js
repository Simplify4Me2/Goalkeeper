import React from 'react';
import { render } from '@testing-library/react';
import Footer from './Footer';

test('renders Copyright', () => {
    const { getByText } = render(<Footer />);
    const linkElement = getByText(/© Simonito/i)
    expect(linkElement).toBeInTheDocument();
})