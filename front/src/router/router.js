import {createRouter, createWebHistory} from "vue-router";

function lazyPage(pages) {
    return () => import(`../pages/${pages}.vue`)
}

const routes = [
    { path: '/', redirect: '/login' },
    { path: '/login', name: "login", component: lazyPage('LoginPage') },
    { path: '/profile', name: "profile", component: lazyPage('ProfilePage') },
]

const router = createRouter({
    routes,
    history: createWebHistory(process.env.BASE_URL)
});

export default router;
