import React from 'react';
import { render } from '@testing-library/react';
import Footer from '../footer/Footer';

it('renders Copyright', () => {
    const { getByText } = render(<Footer />);
    const linkElement = getByText(/© Simonito/i)
    expect(linkElement).toBeInTheDocument();
    // const div = document.createElement('div');

})