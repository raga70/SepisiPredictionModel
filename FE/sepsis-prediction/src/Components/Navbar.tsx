import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import MedicalServicesIcon from '@mui/icons-material/MedicalServices';
import {useNavigate} from "react-router-dom";
const pages = ['Home', 'Predict', 'ExtraAtentionPatients'];
//const settings = ['Profile', 'Account', 'Dashboard', 'Logout'];
const Navbar = () => {
    const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null);
    const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(null);

    const navigate = useNavigate();
    const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorElNav(event.currentTarget);
    };
    const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorElUser(event.currentTarget);
    };

    const handlePageClicked = (page:string) => {
        navigate(page);
        setAnchorElNav(null);
    };

    const handleCloseUserMenu = () => {
        setAnchorElUser(null);
    };

    return (
        <AppBar sx={{backgroundColor:"#98E2C6", color:"#545C52" }} position="static">
            <Container style={{textTransform:"none"}} maxWidth="xl">
                <Toolbar disableGutters>
                    <MedicalServicesIcon sx={{ display: { xs: 'none', md: 'flex' } , textTransform:"none !important"  , mr: 1 }} />
                    <Typography
                        variant="h6"
                        noWrap
                        component="a"
                        href="/"
                        sx={{
                            mr: 2,
                            display: { xs: 'none', md: 'flex' },
                            fontFamily: 'monospace',
                            fontWeight: 700,
                            letterSpacing: '.3rem',
                            color: 'inherit',
                            textDecoration: 'none',
                        }}
                    >
                        SepsisPredictor3000
                    </Typography>

                    <Box sx={{ flexGrow: 1,   display: { xs: 'flex', md: 'none' } }}>
                        <IconButton
                            size="large"
                            aria-label="account of current user"
                            aria-controls="menu-appbar"
                            aria-haspopup="true"
                            onClick={handleOpenNavMenu}
                            color="inherit"
                        >
                            <MenuIcon />
                        </IconButton>
                        <Menu
                            id="menu-appbar"
                            anchorEl={anchorElNav}
                            anchorOrigin={{
                                vertical: 'bottom',
                                horizontal: 'left',
                            }}
                            keepMounted
                            transformOrigin={{
                                vertical: 'top',
                                horizontal: 'left',
                            }}
                            open={Boolean(anchorElNav)}
                            onClose={handlePageClicked}
                            sx={{
                                textTransform:"lowercase" ,
                                display: { xs: 'block', md: 'none' },
                            }}
                        >
                            {pages.map((page) => (
                                <Button  style={{textTransform:"none"}}    key={page} onClick={()=>{handlePageClicked(page)}}>
                                    <Typography  style={{textTransform:"none"}} textAlign="center">{page}</Typography>
                                </Button>
                            ))}
                        </Menu>
                    </Box>
                    <MedicalServicesIcon sx={{ display: { xs: 'flex', md: 'none' }, mr: 1 }} />
                    <Typography
                        variant="h5"
                        noWrap
                        component="a"
                        href=""
                        sx={{
                            mr: 2,
                            display: { xs: 'flex', md: 'none' },
                            flexGrow: 1,
                            fontFamily: 'monospace',
                            fontWeight: 700,
                            letterSpacing: '.3rem',
                            color: 'inherit',
                            textDecoration: 'none',
                        }}
                    >
                        SepsisPredictor3000
                    </Typography>
                    {/* eslint-disable-next-line no-restricted-globals */}
                    <Box sx={{flexGrow:50, marginLeft:"50vw",  justifySelf:"flex-end", display: { xs: 'none', md: 'flex' } }}>
                        {pages.map((page) => (
                            <Button
                                key={page}
                                onClick={()=>{handlePageClicked(page)}}
                                sx={{ textTransform:"none", color:"#545C52", fontWeight:"bold", fontSize:"17px" , my: 2,  display: 'block' }}
                            >
                                {page}
                            </Button>
                        ))}
                    </Box>

                    
                </Toolbar>
            </Container>
        </AppBar>
    );
};
export default Navbar;
